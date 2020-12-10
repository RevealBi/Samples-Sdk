# Step by step Reveal Sdk Web sample created from scratch
A sample demonstrating embedding Reveal Web Sdk in Asp Net Core 3.1 Mvc project from scratch.

## Here's the list with different steps this project goes through

1. Create new Asp NetCore 3.1 MVC application.
2. Add nuget package reference to Microsoft.AspNetCore.Mvc.NewtonsoftJson version 3.1.10 and added AddNewtonsoftJson() to the services in ConfigureServices in order to configure the asp application to use Newtonsoft.Json serializer instead of the System.Text.Json serializer as advised here https://dotnetcoretutorials.com/2019/12/19/using-newtonsoft-json-in-net-core-3-projects/ .
3. Install the latest Reveal.Sdk.Web.AspNetCore.Trial nuget package.
4. Change the Startup constructor so it gets also the IWebHostEnvironmen as argument in order to store the WebRootPath.
5. Creating a basic implementation of RevealSdkContextBase and registering it with the ASP services.
6. Adding client and server side javascript files to the project.
7. Reference the infragistics.reveal.js and it's dependencies - dayjs & quilljs in the _Lauyout.cshtml. Modifying the index.cshtml page so it now renders an empty dashbaord.
8. Change the index.cshtml page so it requests a dashboard from the server and tries to render it - unsuccessfully at this point.
9. Add dashboard(.rdash) files to the project and mark then as EmbeddedResource. Update the  RevealContext.GetDashboardAsync implementation to be loading and delivering the requested dashboard if available. After this step the Marketing sample dashboard should be successfully loaded and rendered in the browser.
10. Change the Index.cshtml to be requesting the Sales dashboard to render.
11. Reveal client Sdk is using Roboto fonts by default so add the fonts to the project and change the client side part so a dashboard is loaded when the roboto fonts were loaded in the browser.

## You could follow the commits in this branch to follow up each step of the process
* Branch history - https://github.com/RevealBi/Samples-Sdk/commits/WebProjectFromScratch/Reveal.Web.NetCore3.1
* Sample project root folder - https://github.com/RevealBi/Samples-Sdk/tree/WebProjectFromScratch/Reveal.Web.NetCore3.1
