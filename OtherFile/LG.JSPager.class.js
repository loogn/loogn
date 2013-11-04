/*js分页控件*/
var JSPagerList=[]; //这里主要是为了在调用时不传递对象的名称
var JSPager=function(params){
    JSPagerList[JSPagerList.length]=this;    
    this.pageIndex=1;  //当前页码
    this.pageSize=10;   //每页条数
    this.barSize=5;    //分页条显示的页码数
    this.totalRecord=0;  //总记录行数
    this.pageChanged=null;  //分页时调用的方法，有当前页做为参数
    this.divPager="divPager"; //显示的容器id
    this.totalPage=0;     //总页数
    this.barTemplate="{bar}&nbsp;&nbsp;共{totalPage}页{totalRecord}条&nbsp;{goto}"; //显示模板
    this.autoHide=true ; //是否自动隐藏
    this.showFirst=true; //在totalPage>barSize时是自动否显示第一页链接
    this.showLast=true;//在totalPage>barSize时是自动否显示最后一页链接
    this.autoHideGoTo=true;
    
     //填充参数
    if(params.pageIndex) {
        this.pageIndex =parseInt(params.pageIndex);
    }
    if(params.pageSize)
        this.pageSize =parseInt(params.pageSize);
    if(params.barSize)
        this.barSize=params.barSize;
    if(params.totalRecord)
        this.totalRecord=parseInt(params.totalRecord);
    if(params.pageChanged)
        this.pageChanged =params.pageChanged;
    if(params.divPager)
        this.divPager =params.divPager;
    if(params.barSize)
        this.barSize=parseInt(params.barSize);
    if(params.barTemplate)
        this.barTemplate =params.barTemplate;
    if(params.autoHide==false)
        this.autoHide =false ;
    if(params.showFirst==false)
        this.showFirst =false ;
    if(params .showLast=false)
        this.showLast =false ;
    if(params.autoHideGoTo==false)
        this.autoHideGoTo=false ;
}

JSPager.prototype._getLink=function(pager,index,txt){
    if(!txt)
        var txt=index ;
    return '<a href="javascript:;" style="margin: 2px 5px;border: 1px solid #6d8cad;color: #0269BA;padding: 2px 5px;text-decoration: none;" onclick=\'' + pager + '.show({pageIndex:' + index + '})\'>' + txt + '</a>';
}

JSPager.prototype.show=function(params){

    var isFire=true;
    if(params){ //填充参数
        if(params.pageIndex)
            this.pageIndex=params.pageIndex;
        else
            this.pageIndex =1;
        if(params.totalRecord)
            this.totalRecord=params.totalRecord;        
        if(params.fire===false)
            isFire=false ;
    }
    var pager='';
    for (var i=0;i<JSPagerList.length;i++){//找出是哪一个pager调用show();
        if(JSPagerList[i]==this){
            pager ="JSPagerList["+i+"]";
        }
    }
    
    var startPage=0;  //分页条起始页
    var endPage=0;    //分页条终止页
    var showFirst=true ;
    var showLast=true ;
    if(isNaN (this.pageIndex )){
        this.pageIndex =1;
    }
    
    this.pageIndex=parseInt(this.pageIndex);
    if(this.pageIndex<=0)
        this.pageIndex =1;
    if(this.pageIndex*this.pageSize >this.totalRecord ){
        this.pageIndex=Math.ceil (this.totalRecord/this.pageSize);
    }
    
    if(this.pageChanged && isFire){ //分页事件
        try{
            this.pageChanged(this.pageIndex);
        }
        catch(e){;}
    }
        
    if(this.totalRecord==0){ //如果没数据
        document.getElementById(this.divPager).innerHTML="";
        return this;
    }
    
    this.totalPage=Math.ceil(this.totalRecord/this.pageSize);
    if(this.autoHide && this.totalRecord<=this.pageSize){   //自动隐藏
       document.getElementById(this.divPager).innerHTML="";
       return this;
    }
    
    if(this.totalPage <=this.barSize){
        startPage =1;
        endPage =this.totalPage;
        showLast =showFirst =false ;
    }
    else{
        if(this.pageIndex<=Math.ceil (this.barSize/2)){ //最前几页时
            startPage =1;
            endPage =this.barSize;
            showFirst=false;
        }
        else if(this.pageIndex>(this.totalPage-this.barSize/2)){ //最后几页时
            startPage =this.totalPage-this.barSize+1;
            endPage =this.totalPage;
            showLast =false;
        }
        else{                                          //中间的页时
            startPage =this.pageIndex -Math.ceil (this.barSize/2)+1;            
            endPage =this.pageIndex +Math.floor(this.barSize/2);   
        }
        if(this.totalPage <=(this.barSize*1.5)){
                showLast =showFirst =false;        
        }
    }
    
    var barHtml="";  //分页条
    barHtml+=this.pageIndex==1?"":this._getLink(pager,this.pageIndex-1,"上一页");
    if(showFirst && this.showFirst){
        barHtml +=this._getLink (pager,1)+"<span>...</span>";
    }
    for(var index=startPage ;index <=endPage ;index ++){
        
        if(index==this.pageIndex){
            barHtml +="<span style='color:red;font-weight:blod; '>"+index+"</span>";
        }
        else{
            barHtml +=this._getLink(pager,index);
        }
    }
    if(showLast && this.showLast){
        barHtml +="<span>...</span>"+this._getLink (pager,this.totalPage);
    }
    barHtml+=this.pageIndex==this.totalPage? "":this._getLink(pager,this.pageIndex+1,"下一页");
    
    var gotoHtml="";  //goto框及按钮
    if(this.barTemplate.indexOf("{goto}")>0){
        if((this.autoHideGoTo && this.totalPage>15) || this.autoHideGoTo==false){            
            var txtid=pager+"_goIndex";
            var indexVal="document.getElementById(\""+txtid+"\").value";
            gotoHtml +="<input type='text' onkeypress='if(event.keyCode==13){"+pager+".show({pageIndex:"+indexVal+"})}' id='"+txtid+"' value="+this.pageIndex+" style='width:30px'>";
            gotoHtml +='&nbsp;<input type="button" class="page_bg" value="go" onclick=\''+pager+'.show({pageIndex:'+indexVal+'})\'>';
        }
    }
    //替换模板
    var pagerHtml=this.barTemplate.replace("{bar}",barHtml)
                                  .replace("{totalRecord}",this.totalRecord)
                                  .replace("{pageIndex}",this.pageIndex)
                                  .replace("{totalPage}",this.totalPage)
                                  .replace("{goto}",gotoHtml);

    document.getElementById(this.divPager).innerHTML=pagerHtml;
    return this ;   
};
