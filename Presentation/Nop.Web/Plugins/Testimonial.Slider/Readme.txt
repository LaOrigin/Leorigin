

Before Installation : 

Please follow below instructions before plugin installation.

 In order to install testimonial plugin successfully, two folders (path is given below) will need access permissions.
1.If you are working in your local machin, please go to below paths in your project source directory, right click on both folders, and uncheck(if checked) the "Read-only" checkbox, then click apply and then click ok.

   Folder 1 > Your drive\...path to your project source folder\...Presentation\Nop.Web\Views
   Folder 2 > Your drive\...path to your project source folder\...Presentation\Nop.Web\Themes

2. If you are working on server then please go to above path in your project source directory, right click on both folders, go to security tab, click on Edit to change permission , select "NETWORK SERVICES" and check "Full control" checkbox under "Allow" column, then click apply and then click ok. 
=================================================================

Notes :

'Copy local' property of the referenced assemblies are set to 'false'.
We know that they're referenced by the main web applications. So there's no need to deploy them.
It can dramatically reduce package size.


Set project output path to ..\..\Presentation\Nop.Web\Plugins\{PluginName}\ (both 'Release' and 'Debug' configurations)


All views (cshtml files) and web.config file should have "Build action" set to "Content" and "Copy to output directory" set to "Copy if newer"

