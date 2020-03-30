SignalR Provider for NCache 5.0

       Instructions:
       
              ►      Dot Net framework 4.5 or later is required.
		
              ►      NCache backplane for scaling out ASP.NET SignalR applications in web-farm. 
                                          
              ►      Alachisoft.NCache.SignalR NuGet package adds reference to
                     1 - Alachisoft.NCache.SignalR.dll
                     2 - SignalR Core dependencies
              
              ►      To use NCache backplane for SignalR scaling out ASP.Net Applications go to ConfigureSignalR function of startup class and use GlobalHost.DependencyResolver.UseNCache()
                     1 - Create an instance of NCacheScaleoutConfiguration with required values like CacheName and AppID
                     2 - Pass this newly created instance of NCacheScaleoutConfiguration to GlobalHost.DependencyResolver.UseNCache() function
				    
			  ►   	 This nuget package copies Client.ncconf and Config.ncconf to local directory of the application. NCache tries to read cache information 
					 from local configs first. If the required information is not found from local configs, it reads that information from configs inside NCache 
					 installation directory.If NCache is not installed on the machine where application is running, please make sure that all required information
				     is given in these local configs.
			  
			  ►   	 Purpose of Client.ncconf:
				     Client.ncconf contains the information about the cache servers of each cache application needs to access.
			
			  ►      Purpose of Config.ncconf:
				     Config.ncconf that is copied locally is used for local inproc cache and inproc client caches. For client cache, config.ncconf must also contain the name for the clustered cache which this client cache is a part of.		 
              
              ►      For fruther info, please visit:  http://www.alachisoft.com/resources/docs/ncache/help/aspnet-signalr.html
