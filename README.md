BaseConverterAPI
================

**Author:** Ndivhuwo Neswiswi**Email:** [ndivhuswiswi@gmail.com](mailto:ndivhuswiswi@gmail.com)**Date:** 2025-10-14

A simple **web API built with ASP.NET Core (C#)** to convert numbers between different bases — from **binary (2) to base 36**.

This project is part of my **learning journey** to understand **how to build a web API**, how it works, and how to host it. I chose number base conversion because it’s **fun, easy to code, and demonstrates a working API** without taking too long — perfect for practicing real-world API development.

Features
--------

*   Convert numbers between **any base from 2 to 36**
    
*   RESTful API with **POST requests**
    
*   Returns structured JSON with original number and converted value
    
*   Handles **uppercase/lowercase letters automatically** for bases above 10
    
*   Built with **clean architecture** (Models, Services, Controllers)
    
*   Fully testable with **Swagger UI**
    
*   Ready to deploy to **Azure App Service**
    

Installation & Running Locally
------------------------------

1.  **Clone the repository**
    

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   git clone https://github.com/23026475/BaseConverterAPI.git  cd BaseConverterAPI   `

1.  **Open in Visual Studio**
    

*   Open BaseConverterAPI.sln
    

1.  **Restore dependencies & build**
    

*   Visual Studio should automatically restore NuGet packages.
    
*   Build the solution (Ctrl+Shift+B)
    

1.  **Run the project**
    

*   Press F5 to run with Swagger UI in your browser
    
*   https://localhost:7082
    

Swagger Testing
---------------

*   Navigate to https://localhost:7082/swagger
    
*   You can see and test the API endpoints directly in the browser.
    
*   **POST /api/Convert** endpoint is available for testing number conversions.
    
Learning Outcomes
-----------------

Through this project, I learned:

*   How **web APIs** work and how to structure them using ASP.NET Core
    
*   Using **Controllers, Services, and Models** for clean architecture
    
*   How to **validate inputs** and handle errors gracefully
    
*   How to **test APIs** using Swagger UI
    
*   How to **prepare an API for deployment** (e.g., Azure App Service)
    

This project demonstrates a complete **backend workflow**, making it **portfolio-ready**, accessible, and extendable.
   

**Enjoy converting numbers all the way up to base 36!**
API Usage
---------

**Endpoint:**POST /api/Convert

```json
{
  "input": "1010",
  "fromBase": 2,
  "toBase": 10
}
response:{
  "original": "1010",
  "fromBase": 2,
  "toBase": 10,
  "converted": "10"
}
