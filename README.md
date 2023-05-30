# Enhanced component properties.

Finally you can create custom events with behavior properties and create user defined function with property parameters.

Below is the application which you can import from PowerApps-Canvas folder. The purpose of this application is to manage a games' catalogue.

![image](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/f63537be-595b-4a39-abeb-0b7220d34070)

The red box indicates the component whose task is to render the list of games retrieved via the custom connector. From the Tree View, it is given the name ComponentListGame_1.

The component fire a custom event thanks to behavior properties, however to use this property you have to enable it. 

Go to settings -> Upcoming features -> Experimental and then you have to enable Enhanced component properties.

![image](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/12f45243-dd0c-4b26-a43c-5cd684d5dc34)


The app uses a custom connector which consent to consume a custom set REST API that I developed for this scenario. You can find the entire solution inside Code-MinimalAPI folder. It's a .net 7 web API project using minimal api approch.

![image](https://github.com/N1C0-95/PowerApps-EnhancedComponentProperties/assets/74839804/8bbee8e9-b4e2-4ed6-be35-189aad7d6168)

You can use that solution and deploy it where you prefer. 

Inside CustomConnector folder you can find the swagger of custom connector that you can import directly in your environment. Don't forgeto to change the host name with yours.

You can read the entire description in my blog ( https://nicoloferranti.net/enhanced-component-properties ).
