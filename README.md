# Enhanced component properties.

Finally you can create custom events with Event properties and create user-defined function with property parameters.

Below you can see a preview of the canvas app which you can import from PowerApps-Canvas folder. The purpose of this application is to manage a games' catalogue.

![GameStoreApp](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/4b9cac09-0b68-4bed-b002-7755e04737f4)

The list is the component with the aim to render all the games available and apply a discount. It interacts with the main app through a custom event.

To create a new Event you have to enable enhanced component property. 

Go to settings -> Upcoming features -> Experimental and then you have to enable Enhanced component properties.

![image](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/12f45243-dd0c-4b26-a43c-5cd684d5dc34)


The app uses a custom connector that consent to consume a custom set REST API that I developed for this scenario. You can find the entire solution inside Code-MinimalAPI folder. It's a .net Web API project that exploits an approach on minimal API approach.

![image](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/8bbee8e9-b4e2-4ed6-be35-189aad7d6168)

You can use that solution and deploy it where you prefer. 

Inside CustomConnector folder you can find the swagger of custom connector that you can import directly into your environment. Don't forget to change the hostname with yours.

You can read the entire description in my blog ( https://nicoloferranti.net/enhanced-component-properties ).
