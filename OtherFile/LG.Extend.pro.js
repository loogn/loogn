/* prototype扩展*/
String.prototype.format = function(args) { 
    var result = this;
    if (arguments.length > 0) {    
        if (arguments.length == 1 && typeof (args) == "object") {
            var newObj={};
            if(LG.tiled){
                LG.tiled(newObj,args);
            }else{
                newObj=args
            }
            for (var key in newObj) {
                if(newObj[key]!=undefined){
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, newObj[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined && typeof (arguments[i])!="function") {
                    var reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}

/*
    取出类名为tplContainer的元素innerHTML保证在元素data("tpl")里
    .tplContainer{display:none;}
*/
var LG=(function(lg){
    lg.initTpl=function(){
        $(".tplContainer").each(function() { //取出模板
            $(this).data("tpl", unescape($(this).html())).empty().removeClass("tplContainer");
        })
    }
    return lg;
}(LG||{}));

/* Array.exists */
Array.prototype.exists = function(element,attr) {
    for (var i = 0; i < this.length; i++) {
        if(attr){
            if (this[i][attr] == element[attr]) {
                return true;
            }
        }
        else{
            if (this[i] == element) {
                return true;
            }
        }
    }
    return false;
}

Array.prototype.del=function(n) {　//n表示第几项，从0开始算起。
//prototype为对象原型，注意这里为对象增加自定义方法的方法。
　if(n<0)　//如果n<0，则不进行任何操作。
　　return this;
　else
　　return this.slice(0,n).concat(this.slice(n+1,this.length));
　　/*
　　　concat方法：返回一个新数组，这个新数组是由两个或更多数组组合而成的。
　　　　　　　　　这里就是返回this.slice(0,n)/this.slice(n+1,this.length)
　　 　　　　　　组成的新数组，这中间，刚好少了第n项。
　　　slice方法： 返回一个数组的一段，两个参数，分别指定开始和结束的位置。
　　*/
}

Array.prototype.delVal=function(val,attr){
    var newArr=this;
    for(var i=0;i<newArr.length;i++){
        if(attr){
            if(newArr[i][attr]==val[attr])
                return newArr.del(i);
        }
        else{
            if(newArr[i]==val)
                return newArr.del(i);
        }
    }
    return newArr;
};
