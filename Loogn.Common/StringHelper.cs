using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace Loogn.Common
{
    public static partial class StringHelper
    {
        public static class Reg
        {
            /// <summary>
            /// 邮箱正则表达式
            /// </summary>
            public static readonly string RegEmail = "^[-_A-Za-z0-9]+@([_A-Za-z0-9]+.)+[A-Za-z0-9]{2,3}$";
            public static readonly string RegEmailNoEnds = "[-_A-Za-z0-9]+@([_A-Za-z0-9]+.)+[A-Za-z0-9]{2,3}";

            /// <summary>
            /// 固话号正则表达式
            /// </summary>
            public static readonly string RegTelephone = "^(0[0-9]{2,3}-)?([2-9][0-9]{6,7})+(-[0-9]{1,4})?$";
            public static readonly string RegTelephoneNoEnds = "(0[0-9]{2,3}-)?([2-9][0-9]{6,7})+(-[0-9]{1,4})?";

            /// <summary>
            /// 手机号正则表达式
            /// </summary>
            public static readonly string RegCellphone = "^1[3,5,8]{1}[0-9]{1}[0-9]{8}$";
            public static readonly string RegCellphoneNoEnds = "1[3,5,8]{1}[0-9]{1}[0-9]{8}";

            /// <summary>
            /// 作为js字符串前处理表达式
            /// </summary>
            public static readonly string RegJSString = "['\"\\\n\r\t]{1}";
        }

        public static string MD5Encrypt(string source, Encoding bytesEncoding)
        {
            byte[] sourceBytes = bytesEncoding.GetBytes(source);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashedBytes = md5.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
            //StringBuilder buffer = new StringBuilder(hashedBytes.Length);
            //foreach (byte item in hashedBytes)
            //{
            //    buffer.AppendFormat("{0:X2}", item);
            //}
            //return buffer.ToString();
        }
        public static string MD5Encrypt(string plaintext)
        {
            return MD5Encrypt(plaintext, Encoding.UTF8);
        }

        /// <summary>   
        /// 利用DES加密算法加密字符串（可解密）   
        /// </summary>   
        /// <param name="plaintext">被加密的字符串</param>   
        /// <param name="key">密钥（只支持8个字节的密钥）</param>   
        /// <returns>加密后的字符串</returns>   
        public static string DESEncrypt(string plaintext, string key)
        {
            //访问数据加密标准(DES)算法的加密服务提供程序 (CSP) 版本的包装对象   
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);　//建立加密对象的密钥和偏移量   
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法   

            byte[] inputByteArray = Encoding.Default.GetBytes(plaintext);//把字符串放到byte数组中   

            MemoryStream ms = new MemoryStream();//创建其支持存储区为内存的流　   
            //定义将数据流链接到加密转换的流   
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //上面已经完成了把加密后的结果放到内存中去   
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }  
        /// <summary>   
        /// 利用DES解密算法解密密文（可解密）   
        /// </summary>   
        /// <param name="ciphertext">被解密的字符串</param>   
        /// <param name="key">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>   
        /// <returns>返回被解密的字符串</returns>   
        public static string DESDecrypt(string ciphertext, string key)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[ciphertext.Length / 2];
                for (int x = 0; x < ciphertext.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(ciphertext.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(key);　//建立加密对象的密钥和偏移量，此值重要，不能修改   
                des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                //建立StringBuild对象，createDecrypt使用的是流对象，必须把解密后的文本变成流对象   
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return "error";
            }
        }

        #region html
        /// <summary>
        /// 移除HTML标记
        /// </summary>
        /// <param name="inputString">html源码</param>
        /// <param name="Tag">要设置的标记，如img,h1等</param>
        /// <returns></returns>
        public static string RemoveHTMLTag(string strHtml, string Tag = "")
        {
            if (string.IsNullOrEmpty(Tag))
            {
                Regex regex = new Regex("<(.[^>]*)>", RegexOptions.IgnoreCase);
                return regex.Replace(strHtml, "");
            }

            ArrayList TagList = new ArrayList();
            int Top = -1;
            Match m;
            Regex r;
            if (Tag.ToUpper() == "IMG" || Tag.ToUpper() == "BR")
            {
                strHtml = Regex.Replace(strHtml, "\\<" + Tag + @"[\s\S]*?/>", "", RegexOptions.IgnoreCase);
            }
            else
            {
                r = new Regex("\\</?" + Tag, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                for (m = r.Match(strHtml); m.Success; )
                {
                    string TagValue = m.Value;
                    int TagIndex = m.Index;
                    if (TagValue.ToUpper() == @"<" + Tag.ToUpper())
                    {
                        Top = TagList.Add(TagIndex);
                        m = m.NextMatch();
                    }
                    else if (TagValue.ToUpper() == @"</" + Tag.ToUpper())
                    {
                        if (TagList.Count > 0)
                        {
                            int DIndex = (int)TagList[Top];
                            strHtml = strHtml.Remove(DIndex, TagIndex - DIndex + Tag.Length + 3);
                            m = r.Match(strHtml);
                        }
                        else
                        {
                            m = m.NextMatch();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return strHtml;
        }
        /// <summary>
        /// 还原恢复html表示 如回车-><br/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RecoverHTML(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace("<", "&lt;");
                text = text.Replace(">", "&gt;");
                text = text.Replace(" ", "&nbsp;");
                text = text.Replace("\n", "<br/>");
                text = text.Replace("\r\n", "<br/>");
                return text;
            }
            else
            {
                return text;
            }
        }
        #endregion


        #region 截取
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="number">截取数量</param>
        /// <returns></returns>
        public static string InterceptString(string str, int number)
        {
            if (str == null || str.Length == 0 || number <= 0) return "";
            int iCount = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str);
            if (iCount > number)
            {
                int iLength = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int iCharLength = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(new char[] { str[i] });
                    iLength += iCharLength;
                    if (iLength == number)
                    {
                        str = str.Substring(0, i + 1);
                        break;
                    }
                    else if (iLength > number)
                    {
                        str = str.Substring(0, i);
                        break;
                    }
                }
            }
            return str;

        }
        /// <summary>
        /// 截取字符串，以“.”结束
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="number">截取数量</param>
        /// <returns></returns>
        public static string InterceptStringEndDot(string str, int number)
        {
            if (str == null || str.Length == 0 || number <= 0) return "";
            int iCount = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(str);
            if (iCount > number)
            {
                int iLength = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    int iCharLength = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(new char[] { str[i] });
                    iLength += iCharLength;
                    if (iLength == number)
                    {
                        str = str.Substring(0, i + 1) + "…";
                        break;
                    }
                    else if (iLength > number)
                    {
                        str = str.Substring(0, i) + "…";
                        break;
                    }
                }
            }
            return str;

        }
        #endregion


        #region 判断

        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsCellPhone(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            Regex rphone = new Regex(Reg.RegCellphone);
            return rphone.IsMatch(str);
        }
        /// <summary>
        /// 是否是固话号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPhone(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            Regex rphone = new Regex(Reg.RegTelephone);
            return rphone.IsMatch(str);
        }

        /// <summary>
        /// 是否是邮箱地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            Regex remail = new Regex(Reg.RegEmail);
            return remail.IsMatch(str);
        }
        /// <summary>
        /// 是否是中国公民身份证号
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool IsIDCard(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return false;
            if (Id.Length == 18)
            {
                return isIDCard18(Id);

            }
            else if (Id.Length == 15)
            {
                return isIDCard15(Id);
            }
            else
            {
                return false;
            }
        }
        private static bool isIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }
        private static bool isIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }


        #endregion

        #region 得到汉字拼音
        /// <summary>
        /// 根据区位得到首字母
        /// </summary>
        /// <param name="GBCode">区位</param>
        /// <returns></returns>
        private static String GetX(int GBCode)
        {
            if (GBCode >= 1601 && GBCode < 1637) return "A";
            if (GBCode >= 1637 && GBCode < 1833) return "B";
            if (GBCode >= 1833 && GBCode < 2078) return "C";
            if (GBCode >= 2078 && GBCode < 2274) return "D";
            if (GBCode >= 2274 && GBCode < 2302) return "E";
            if (GBCode >= 2302 && GBCode < 2433) return "F";
            if (GBCode >= 2433 && GBCode < 2594) return "G";
            if (GBCode >= 2594 && GBCode < 2787) return "H";
            if (GBCode >= 2787 && GBCode < 3106) return "J";
            if (GBCode >= 3106 && GBCode < 3212) return "K";
            if (GBCode >= 3212 && GBCode < 3472) return "L";
            if (GBCode >= 3472 && GBCode < 3635) return "M";
            if (GBCode >= 3635 && GBCode < 3722) return "N";
            if (GBCode >= 3722 && GBCode < 3730) return "O";
            if (GBCode >= 3730 && GBCode < 3858) return "P";
            if (GBCode >= 3858 && GBCode < 4027) return "Q";
            if (GBCode >= 4027 && GBCode < 4086) return "R";
            if (GBCode >= 4086 && GBCode < 4390) return "S";
            if (GBCode >= 4390 && GBCode < 4558) return "T";
            if (GBCode >= 4558 && GBCode < 4684) return "W";
            if (GBCode >= 4684 && GBCode < 4925) return "X";
            if (GBCode >= 4925 && GBCode < 5249) return "Y";
            if (GBCode >= 5249 && GBCode <= 5589) return "Z";
            if (GBCode >= 5601 && GBCode <= 8794)
            {
                String CodeData = "cjwgnspgcenegypbtwxzdxykygtpjnmjqmbsgzscyjsyyfpggbzgydywjkgaljswkbjqhyjwpdzlsgmr"
                 + "ybywwccgznkydgttngjeyekzydcjnmcylqlypyqbqrpzslwbdgkjfyxjwcltbncxjjjjcxdtqsqzycdxxhgckbphffss"
                 + "pybgmxjbbyglbhlssmzmpjhsojnghdzcdklgjhsgqzhxqgkezzwymcscjnyetxadzpmdssmzjjqjyzcjjfwqjbdzbjgd"
                 + "nzcbwhgxhqkmwfbpbqdtjjzkqhylcgxfptyjyyzpsjlfchmqshgmmxsxjpkdcmbbqbefsjwhwwgckpylqbgldlcctnma"
                 + "eddksjngkcsgxlhzaybdbtsdkdylhgymylcxpycjndqjwxqxfyyfjlejbzrwccqhqcsbzkymgplbmcrqcflnymyqmsqt"
                 + "rbcjthztqfrxchxmcjcjlxqgjmshzkbswxemdlckfsydsglycjjssjnqbjctyhbftdcyjdgwyghqfrxwckqkxebpdjpx"
                 + "jqsrmebwgjlbjslyysmdxlclqkxlhtjrjjmbjhxhwywcbhtrxxglhjhfbmgykldyxzpplggpmtcbbajjzyljtyanjgbj"
                 + "flqgdzyqcaxbkclecjsznslyzhlxlzcghbxzhznytdsbcjkdlzayffydlabbgqszkggldndnyskjshdlxxbcghxyggdj"
                 + "mmzngmmccgwzszxsjbznmlzdthcqydbdllscddnlkjyhjsycjlkohqasdhnhcsgaehdaashtcplcpqybsdmpjlpcjaql"
                 + "cdhjjasprchngjnlhlyyqyhwzpnccgwwmzffjqqqqxxaclbhkdjxdgmmydjxzllsygxgkjrywzwyclzmcsjzldbndcfc"
                 + "xyhlschycjqppqagmnyxpfrkssbjlyxyjjglnscmhcwwmnzjjlhmhchsyppttxrycsxbyhcsmxjsxnbwgpxxtaybgajc"
                 + "xlypdccwqocwkccsbnhcpdyznbcyytyckskybsqkkytqqxfcwchcwkelcqbsqyjqcclmthsywhmktlkjlychwheqjhtj"
                 + "hppqpqscfymmcmgbmhglgsllysdllljpchmjhwljcyhzjxhdxjlhxrswlwzjcbxmhzqxsdzpmgfcsglsdymjshxpjxom"
                 + "yqknmyblrthbcftpmgyxlchlhlzylxgsssscclsldclepbhshxyyfhbmgdfycnjqwlqhjjcywjztejjdhfblqxtqkwhd"
                 + "chqxagtlxljxmsljhdzkzjecxjcjnmbbjcsfywkbjzghysdcpqyrsljpclpwxsdwejbjcbcnaytmgmbapclyqbclzxcb"
                 + "nmsggfnzjjbzsfqyndxhpcqkzczwalsbccjxpozgwkybsgxfcfcdkhjbstlqfsgdslqwzkxtmhsbgzhjcrglyjbpmljs"
                 + "xlcjqqhzmjczydjwbmjklddpmjegxyhylxhlqyqhkycwcjmyhxnatjhyccxzpcqlbzwwwtwbqcmlbmynjcccxbbsnzzl"
                 + "jpljxyztzlgcldcklyrzzgqtgjhhgjljaxfgfjzslcfdqzlclgjdjcsnclljpjqdcclcjxmyzftsxgcgsbrzxjqqcczh"
                 + "gyjdjqqlzxjyldlbcyamcstylbdjbyregklzdzhldszchznwczcllwjqjjjkdgjcolbbzppglghtgzcygezmycnqcycy"
                 + "hbhgxkamtxyxnbskyzzgjzlqjdfcjxdygjqjjpmgwgjjjpkjsbgbmmcjssclpqpdxcdyykypcjddyygywchjrtgcnyql"
                 + "dkljczzgzccjgdyksgpzmdlcphnjafyzdjcnmwescsglbtzcgmsdllyxqsxsbljsbbsgghfjlwpmzjnlyywdqshzxtyy"
                 + "whmcyhywdbxbtlmswyyfsbjcbdxxlhjhfpsxzqhfzmqcztqcxzxrdkdjhnnyzqqfnqdmmgnydxmjgdhcdycbffallztd"
                 + "ltfkmxqzdngeqdbdczjdxbzgsqqddjcmbkxffxmkdmcsychzcmljdjynhprsjmkmpcklgdbqtfzswtfgglyplljzhgjj"
                 + "gypzltcsmcnbtjbhfkdhbyzgkpbbymtdlsxsbnpdkleycjnycdykzddhqgsdzsctarlltkzlgecllkjljjaqnbdggghf"
                 + "jtzqjsecshalqfmmgjnlyjbbtmlycxdcjpldlpcqdhsycbzsckbzmsljflhrbjsnbrgjhxpdgdjybzgdlgcsezgxlblg"
                 + "yxtwmabchecmwyjyzlljjshlgndjlslygkdzpzxjyyzlpcxszfgwyydlyhcljscmbjhblyjlycblydpdqysxktbytdkd"
                 + "xjypcnrjmfdjgklccjbctbjddbblblcdqrppxjcglzcshltoljnmdddlngkaqakgjgyhheznmshrphqqjchgmfprxcjg"
                 + "dychghlyrzqlcngjnzsqdkqjymszswlcfqjqxgbggxmdjwlmcrnfkkfsyyljbmqammmycctbshcptxxzzsmphfshmclm"
                 + "ldjfyqxsdyjdjjzzhqpdszglssjbckbxyqzjsgpsxjzqznqtbdkwxjkhhgflbcsmdldgdzdblzkycqnncsybzbfglzzx"
                 + "swmsccmqnjqsbdqsjtxxmbldxcclzshzcxrqjgjylxzfjphymzqqydfqjjlcznzjcdgzygcdxmzysctlkphtxhtlbjxj"
                 + "lxscdqccbbqjfqzfsltjbtkqbsxjjljchczdbzjdczjccprnlqcgpfczlclcxzdmxmphgsgzgszzqjxlwtjpfsyaslcj"
                 + "btckwcwmytcsjjljcqlwzmalbxyfbpnlschtgjwejjxxglljstgshjqlzfkcgnndszfdeqfhbsaqdgylbxmmygszldyd"
                 + "jmjjrgbjgkgdhgkblgkbdmbylxwcxyttybkmrjjzxqjbhlmhmjjzmqasldcyxyqdlqcafywyxqhz";
                String _gbcode = GBCode.ToString();
                int pos = (Convert.ToInt16(_gbcode.Substring(0, 2)) - 56) * 94 + Convert.ToInt16(_gbcode.Substring(_gbcode.Length - 2, 2));
                return CodeData.Substring(pos - 1, 1);
            }
            return " ";
        }

        /// <summary>
        /// 得到单个汉字首字母大写
        /// </summary>
        /// <param name="OneIndexTxt"></param>
        /// <returns></returns>
        private static string GetOneIndex(string OneIndexTxt)
        {
            if (Convert.ToChar(OneIndexTxt) >= 0 && Convert.ToChar(OneIndexTxt) < 256)
                return OneIndexTxt;
            else
            {
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] unicodeBytes = Encoding.Unicode.GetBytes(OneIndexTxt);
                byte[] gb2312Bytes = Encoding.Convert(Encoding.Unicode, gb2312, unicodeBytes);
                return GetX(Convert.ToInt32(
                 String.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[0]) - 160)
                 + String.Format("{0:D2}", Convert.ToInt16(gb2312Bytes[1]) - 160)
                 ));
            }
        }
        /// <summary>
        /// 得到汉字字符串的首字母大写
        /// </summary>
        /// <param name="IndexTxt"></param>
        /// <returns></returns>
        public static string GetChineseIndex(string IndexTxt)
        {
            string _Temp = null;
            for (int i = 0; i < IndexTxt.Length; i++)
                _Temp = _Temp + GetOneIndex(IndexTxt.Substring(i, 1));
            return _Temp;
        }

        /// <summary>
        /// 得到汉字的拼音字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetChineseSpell(string str, string separator = "")
        {
            int[] iA = new int[]
     {
      -20319 ,-20317 ,-20304 ,-20295 ,-20292 ,-20283 ,-20265 ,-20257 ,-20242 ,-20230
      ,-20051 ,-20036 ,-20032 ,-20026 ,-20002 ,-19990 ,-19986 ,-19982 ,-19976 ,-19805
      ,-19784 ,-19775 ,-19774 ,-19763 ,-19756 ,-19751 ,-19746 ,-19741 ,-19739 ,-19728
      ,-19725 ,-19715 ,-19540 ,-19531 ,-19525 ,-19515 ,-19500 ,-19484 ,-19479 ,-19467
      ,-19289 ,-19288 ,-19281 ,-19275 ,-19270 ,-19263 ,-19261 ,-19249 ,-19243 ,-19242
      ,-19238 ,-19235 ,-19227 ,-19224 ,-19218 ,-19212 ,-19038 ,-19023 ,-19018 ,-19006
      ,-19003 ,-18996 ,-18977 ,-18961 ,-18952 ,-18783 ,-18774 ,-18773 ,-18763 ,-18756
      ,-18741 ,-18735 ,-18731 ,-18722 ,-18710 ,-18697 ,-18696 ,-18526 ,-18518 ,-18501
      ,-18490 ,-18478 ,-18463 ,-18448 ,-18447 ,-18446 ,-18239 ,-18237 ,-18231 ,-18220
      ,-18211 ,-18201 ,-18184 ,-18183 ,-18181 ,-18012 ,-17997 ,-17988 ,-17970 ,-17964
      ,-17961 ,-17950 ,-17947 ,-17931 ,-17928 ,-17922 ,-17759 ,-17752 ,-17733 ,-17730
      ,-17721 ,-17703 ,-17701 ,-17697 ,-17692 ,-17683 ,-17676 ,-17496 ,-17487 ,-17482
      ,-17468 ,-17454 ,-17433 ,-17427 ,-17417 ,-17202 ,-17185 ,-16983 ,-16970 ,-16942
      ,-16915 ,-16733 ,-16708 ,-16706 ,-16689 ,-16664 ,-16657 ,-16647 ,-16474 ,-16470
      ,-16465 ,-16459 ,-16452 ,-16448 ,-16433 ,-16429 ,-16427 ,-16423 ,-16419 ,-16412
      ,-16407 ,-16403 ,-16401 ,-16393 ,-16220 ,-16216 ,-16212 ,-16205 ,-16202 ,-16187
      ,-16180 ,-16171 ,-16169 ,-16158 ,-16155 ,-15959 ,-15958 ,-15944 ,-15933 ,-15920
      ,-15915 ,-15903 ,-15889 ,-15878 ,-15707 ,-15701 ,-15681 ,-15667 ,-15661 ,-15659
      ,-15652 ,-15640 ,-15631 ,-15625 ,-15454 ,-15448 ,-15436 ,-15435 ,-15419 ,-15416
      ,-15408 ,-15394 ,-15385 ,-15377 ,-15375 ,-15369 ,-15363 ,-15362 ,-15183 ,-15180
      ,-15165 ,-15158 ,-15153 ,-15150 ,-15149 ,-15144 ,-15143 ,-15141 ,-15140 ,-15139
      ,-15128 ,-15121 ,-15119 ,-15117 ,-15110 ,-15109 ,-14941 ,-14937 ,-14933 ,-14930
      ,-14929 ,-14928 ,-14926 ,-14922 ,-14921 ,-14914 ,-14908 ,-14902 ,-14894 ,-14889
      ,-14882 ,-14873 ,-14871 ,-14857 ,-14678 ,-14674 ,-14670 ,-14668 ,-14663 ,-14654
      ,-14645 ,-14630 ,-14594 ,-14429 ,-14407 ,-14399 ,-14384 ,-14379 ,-14368 ,-14355
      ,-14353 ,-14345 ,-14170 ,-14159 ,-14151 ,-14149 ,-14145 ,-14140 ,-14137 ,-14135
      ,-14125 ,-14123 ,-14122 ,-14112 ,-14109 ,-14099 ,-14097 ,-14094 ,-14092 ,-14090
      ,-14087 ,-14083 ,-13917 ,-13914 ,-13910 ,-13907 ,-13906 ,-13905 ,-13896 ,-13894
      ,-13878 ,-13870 ,-13859 ,-13847 ,-13831 ,-13658 ,-13611 ,-13601 ,-13406 ,-13404
      ,-13400 ,-13398 ,-13395 ,-13391 ,-13387 ,-13383 ,-13367 ,-13359 ,-13356 ,-13343
      ,-13340 ,-13329 ,-13326 ,-13318 ,-13147 ,-13138 ,-13120 ,-13107 ,-13096 ,-13095
      ,-13091 ,-13076 ,-13068 ,-13063 ,-13060 ,-12888 ,-12875 ,-12871 ,-12860 ,-12858
      ,-12852 ,-12849 ,-12838 ,-12831 ,-12829 ,-12812 ,-12802 ,-12607 ,-12597 ,-12594
      ,-12585 ,-12556 ,-12359 ,-12346 ,-12320 ,-12300 ,-12120 ,-12099 ,-12089 ,-12074
      ,-12067 ,-12058 ,-12039 ,-11867 ,-11861 ,-11847 ,-11831 ,-11798 ,-11781 ,-11604
      ,-11589 ,-11536 ,-11358 ,-11340 ,-11339 ,-11324 ,-11303 ,-11097 ,-11077 ,-11067
      ,-11055 ,-11052 ,-11045 ,-11041 ,-11038 ,-11024 ,-11020 ,-11019 ,-11018 ,-11014
      ,-10838 ,-10832 ,-10815 ,-10800 ,-10790 ,-10780 ,-10764 ,-10587 ,-10544 ,-10533
      ,-10519 ,-10331 ,-10329 ,-10328 ,-10322 ,-10315 ,-10309 ,-10307 ,-10296 ,-10281
      ,-10274 ,-10270 ,-10262 ,-10260 ,-10256 ,-10254
     };
            string[] sA = new string[]
    {
     "a","ai","an","ang","ao"
     ,"ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao","bie","bin"
     ,"bing","bo","bu"
     ,"ca","cai","can","cang","cao","ce","ceng","cha","chai","chan","chang","chao","che"
     ,"chen","cheng","chi","chong","chou","chu","chuai","chuan","chuang","chui","chun"
     ,"chuo","ci","cong","cou","cu","cuan","cui","cun","cuo"
     ,"da","dai","dan","dang","dao","de","deng","di","dian","diao","die","ding","diu"
     ,"dong","dou","du","duan","dui","dun","duo"
     ,"e","en","er"
     ,"fa","fan","fang","fei","fen","feng","fo","fou","fu"
     ,"ga","gai","gan","gang","gao","ge","gei","gen","geng","gong","gou","gu","gua","guai"
     ,"guan","guang","gui","gun","guo"
     ,"ha","hai","han","hang","hao","he","hei","hen","heng","hong","hou","hu","hua","huai"
     ,"huan","huang","hui","hun","huo"
     ,"ji","jia","jian","jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue"
     ,"jun"
     ,"ka","kai","kan","kang","kao","ke","ken","keng","kong","kou","ku","kua","kuai","kuan"
     ,"kuang","kui","kun","kuo"
     ,"la","lai","lan","lang","lao","le","lei","leng","li","lia","lian","liang","liao","lie"
     ,"lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo"
     ,"ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min"
     ,"ming","miu","mo","mou","mu"
     ,"na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie"
     ,"nin","ning","niu","nong","nu","nv","nuan","nue","nuo"
     ,"o","ou"
     ,"pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie","pin","ping"
     ,"po","pu"
     ,"qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que"
     ,"qun"
     ,"ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo"
     ,"sa","sai","san","sang","sao","se","sen","seng","sha","shai","shan","shang","shao","she"
     ,"shen","sheng","shi","shou","shu","shua","shuai","shuan","shuang","shui","shun","shuo","si"
     ,"song","sou","su","suan","sui","sun","suo"
     ,"ta","tai","tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu"
     ,"tuan","tui","tun","tuo"
     ,"wa","wai","wan","wang","wei","wen","weng","wo","wu"
     ,"xi","xia","xian","xiang","xiao","xie","xin","xing","xiong","xiu","xu","xuan","xue","xun"
     ,"ya","yan","yang","yao","ye","yi","yin","ying","yo","yong","you","yu","yuan","yue","yun"
     ,"za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang","zhao"
     ,"zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui"
     ,"zhun","zhuo","zi","zong","zou","zu","zuan","zui","zun","zuo"
    };
            byte[] B = new byte[2];
            string s = "";
            char[] c = str.ToCharArray();
            for (int j = 0; j < c.Length; j++)
            {
                B = System.Text.Encoding.Default.GetBytes(c[j].ToString());
                if ((int)(B[0]) <= 160 && (int)(B[0]) >= 0)
                {
                    s += c[j];
                }
                else
                {
                    for (int i = (iA.Length - 1); i >= 0; i--)
                    {
                        if (iA[i] <= (int)(B[0]) * 256 + (int)(B[1]) - 65536)
                        {
                            s += sA[i];
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(separator) && j != c.Length - 1)
                {
                    s += separator;
                }
            }
            return s;
        }

        #endregion //得到汉字首字母

        public static string GetRandomCode(int count = 4)
        {
            char[] character = { '1', '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            Random rnd = new Random();
            //生成验证码字符串
            char[] codes = new char[count];
            for (int i = 0; i < count; i++)
            {
                codes[i] = character[rnd.Next(character.Length)];
            }
            return new string(codes);
        }

        #region 分隔字符串
        public static string[] Split(string items, params char[] separator)
        {
            if (string.IsNullOrEmpty(items))
            {
                return new string[0];
            }
            return items.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
        public static IEnumerable<T> Split<T>(string items, Func<string, T> parser, params char[] separator)
        {
            if (string.IsNullOrEmpty(items))
            {
                return new T[0];
            }
            var parts = items.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return parts.Select<string, T>(parser);
        }
        #endregion


        /// <summary>
        /// 得到时间路径 parentPath\yyyy\MM\dd.txt
        /// </summary>
        /// <param name="parentPath"></param>
        /// <returns></returns>
        public static string GetLogFilePath(string parentPath)
        {
            var now = DateTime.Now;
            var path = System.IO.Path.Combine(parentPath, now.Year.ToString(), now.Month.ToString());
            var file = now.Day.ToString() + ".txt";

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return path + "\\" + file;
        }
    }
}
