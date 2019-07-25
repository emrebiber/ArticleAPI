# ArticleAPI


1) Create database ve create table scriptleri projenin oldugu folderin icinde bulabilirsiniz. (article_db_scripts.sql)
2) Connection stringi DbConfig.cs classinin icine yerlestiriniz. (https://www.connectionstrings.com/mysql/)
		Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
3) Build .net core project and run.
4) Postman requestleri proje folderin da bulabilirsiniz. (Article API.postman_collection.json)




* Projede istenildigi uzere repository pattern kullanildi. Bunun sebebi datalara kontroller uzerinden direkt olarak erisilmesini engellenmekti.
  Onun disinda reusibility acisindan repository pattern oldukca yararli oldu. Repository patern test konusunda da isimi kolaylastirdi.
  

* Teknolojiler arasinda .net core web api kullanildi. Daha onceden de cokca kullandigim bir teknoloji. Dependency injectionlarin kolaylikla
  yapilmasi beni en cezbeden noktlar arasinda.Genelde mssql ve entity framework ile calismama ragmen bu uygulama da  mysql ve dapper kullanmayi tercih ettim.
  Source control icin git kullandim.   
  
* Daha fazla zaman olsaydi herhangi bir front end framework veya library ile guzel arayuzler yazilabilirdi.
  Onun disinda loglama icin populer packagelar olan Nlog veya Log4Net kutuphaneleri kullanilabilirdi.Fakat ben kendi yazmis oldugum Logger classi tercih ettim 
  ve loglamayi sadece file duzeyinde yaptim. Biraz daha zaman olmasi durumunda database icerisinde bir tableda da loglama yapilabilirdi. 
  
 
* Proje oldukca eglenceli bir projeydi. Ise alimlarda bu tip projelerin verildigi sirketler islerini ne kadar
  dikkate aldiklarini gosteriyorlar. Verilen requirementlarla uygulamayi en basite indirgemeye calistim. Commit ve pushlarimi 
  sik araliklarla yapmaya calistim ki her adimda neler oldugu rahatca gorulebilsin. 
  

