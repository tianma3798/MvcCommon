## 


###### 类定义注意问题点 #######
##  MvcGenerateUrl 
1.类的 Domain 域名 WebConfig 中的 Domain
意思是指定当前域名的 二级域名


## ApplicationError
1. WeConfig 中需要制定 
	<add key="CustomError" value="1"/>
2. 项目中序号制定 HttpErrorContoller 控制器 输出异常信息