set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



ALTER PROC [dbo].[sp_GetAreaJSONData]
AS
	/*
		Author    : loogn
		Function  : 取得地区表Area的json数据表现格式，最下面是调用的例子，可自行修改
		CreateTime: 2011-01-10 14:48:45
	*/
begin

	--生成省JSON数据
	DECLARE @p NVARCHAR(max)
	SET @p='var area_province=['
	SELECT @p=@p+'{id:'+CONVERT(VARCHAR(20),ID)+',name:"'+Name+'"},' FROM area WHERE parentId=0
	SET @p=SUBSTRING(@p,0,LEN(@p))+']'
	PRINT @p
	PRINT ''
	--生成市JSON数据
	DECLARE @c NVARCHAR(max), @id INT ,@name NVARCHAR(50),@oid INT 
	DECLARE cur CURSOR FOR 
	SELECT ID,Name,parentid FROM Area WHERE parentid=0
	PRINT 'var area_city={'
	OPEN cur
		FETCH NEXT FROM cur INTO @id,@name,@oid
		WHILE @@FETCH_STATUS=0
		BEGIN
			SET @c=CONVERT(VARCHAR(20),@id)+':[';
			SELECT @c=@c+'{id:'+CONVERT(VARCHAR(20),ID)+',name:"'+Name+'"},' FROM Area WHERE parentId=@id
			FETCH NEXT FROM cur INTO @id,@name,@oid
			if @@FETCH_STATUS=0
				SET @c=SUBSTRING(@c,0,LEN(@c))+'],'
			ELSE
				SET @c=SUBSTRING(@c,0,LEN(@c))+']'
			PRINT @c 
			
		END
	CLOSE cur
	DEALLOCATE cur
	PRINT '}'
	PRINT ''
	--生成县JSON数据
	DECLARE @x NVARCHAR(max), @id1 INT ,@name1 NVARCHAR(50),@oid1 INT 
	DECLARE cur1 CURSOR FOR 
	SELECT ID,Name,parentid FROM Area WHERE  len(convert(varchar(20),id))=4
	PRINT 'var area_county={'
	OPEN cur1
		FETCH NEXT FROM cur1 INTO @id1,@name1,@oid1
		WHILE @@FETCH_STATUS=0
		BEGIN
			SET @x=CONVERT(VARCHAR(20),@id1)+':[';
			SELECT @x=@x+'{id:'+CONVERT(VARCHAR(20),ID)+',name:"'+Name+'"},' FROM Area WHERE parentid=@id1
			FETCH NEXT FROM cur1 INTO @id1,@name1,@oid1
			if @@FETCH_STATUS=0
				SET @x=SUBSTRING(@x,0,LEN(@x))+'],'
			ELSE
				SET @x=SUBSTRING(@x,0,LEN(@x))+']'
			PRINT @x 
		END
	CLOSE cur1
	DEALLOCATE cur1
	PRINT '}'
	PRINT ''
	PRINT '//以下为调用例子，可根据需要求修改'
	PRINT 'var defOption="<option value=\"\">请选择</option>";'
	PRINT '$(function(){
 	$("#prov").html(defOption);
	$.each(area_province,function(i,kv){
		$("<option>",{html:kv.name,val:kv.id})
		.appendTo($("#prov"));
	})
	
	$("#prov").change(function(){
		$("#city").html(defOption);	
		$("#county").html(defOption);
		if($(this).val()!="")
		{
			var citys=area_city[$(this).val()];
			$.each(citys,function(i,kv){
				$("<option>",{html:kv.name,val:kv.id})
				.appendTo($("#city"));				  
			})
		}
	})	
	$("#city").change(function(){
		$("#county").html(defOption);
		if($(this).val()!="")
		{
			var countys=area_county[$(this).val()];
			$.each(countys,function(i,kv){
				$("<option>",{html:kv.name,val:kv.id})
				.appendTo($("#county"));				  
			})		
		}
	})
})'
	
END


