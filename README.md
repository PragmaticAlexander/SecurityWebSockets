# SecurityWebSockets
Exercise for implementing Web Sockets protocol in Asp.net and Angular

## Explenation
I wrote this security system for my house, but I have to refresh the frontend every time I want to see if any new activity has occured.
I want it to update as soon as something happens.

The backend has a MonitoringSingleton.cs which remains live as long as the program runs. It randomly generates MonitoringEvents with information about what the security system detects.
Something new happens every 20-30 seconds.

## How to run
### Backend
Open /backend/SecurityWebSockets.sln in visual studio and run. A swagger page with endpoints will open.
The MonitoringSingleton starts running immediatly by being instaciated in Program.cs and randomly create new Monitoring events which are also logged in the console.

### Frontend
Open /frontend/SecurityWebsockets and `ng serve`. Surf to localhost:4200.
All current MonitoringEvents are shown, but the list needs to be manually reloaded.