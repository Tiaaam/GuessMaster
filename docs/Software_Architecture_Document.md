# GuessMaster - Software Architecture Document

## Table of contents

- [Table of contens](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#table-of-contents)
- [Introduction](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#1-introduction)
  - [Purpose](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#11-purpose)
  - [Scope](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#12-scope)
  - [Definitions, Acronyms and Abbreviations](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#13-definitions-acronyms-and-abbreviations)
  - [References](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#14-references)
  - [Overview](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#15-overview)
- [Architectural Representation](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#2-architectural-representation)
- [Architectural Goals and Constraints](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#3-architectural-goals-and-constraints)
- [Use-Case View](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#4-use-case-view)
  - [Use-Case Realizations](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#41-use-case-realizations)
- [Logical View](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#5-logical-view)
  - [Overview](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#51-overview)
  - [Architecturally Significant Design Packages](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#52-architecturally-significant-design-packages)
- [Process View](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#6-process-view)
- [Deployment View](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#7-deployment-view)
- [Implementation View](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#7-deployment-view)
  -  [Overwiev](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#81-overwiev)
  -  [Layers](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#82-layers)
- [Size and Performance](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#9-size-and-performance)
- [Quality](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Software_Architecture_Document.md#10-quality)
  
 
## 1. Introduction

### 1.1 Purpose

This document provides a comprehensive architectural overview of the system. It is intended to capture and convey the significant architectural decisions which have been made on the system.

### 1.2 Scope

We realised that user satisfaction is extremely important for our project. Therefore we set usability and performance as our main scope of architecture.

### 1.3 Definitions, Acronyms and Abbreviations

| Abbrevation | Explanation                            |
| ----------- | -------------------------------------- |
| ASR         | Architecture Significant Requirements  |
| ·WIP·       | Work in Progress                       |
| n/r         | not required                           |

### 1.4 References

| Title                                                                                                 | Publishing organization   |
| ------------------------------------------------------------------------------------------------------| ------------------------- |
| [GitHub](https://github.com/Tiaaam/GuessMaster)                                                       | GuessMaster Team          |
| [ASR](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Architecture_Significant_Requirements.md)| GuessMaster Team          |

### 1.5 Overview

In our ASR we decided that an Event-Driven-Architecture suits best for our project, specifically the Mediator topology model. 

## 2. Architectural Representation

This section describes what software architecture is for the current system, and how it is represented in different views:

Use-Case View:
- Our game is divided into 4 essential sections: Select Game, Lobby, Settings and Game.

Logical View:
- The program consists mainly of 3 subsystems named after their classes: RoomController, PlayerController and GameController. 

Process View:
- Our processes are divided into Heavy Weight Processes and Light Weight Processes. 

Deployment View:
- Three components are used for a complete game: Server, Master, Clients.

## 3. Architectural Goals and Constraints

We saved our Architectural Goals and Constraints in the [Architecture Significant Requirements (ASR)](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Architecture_Significant_Requirements.md).

## 4. Use-Case View
  
![UseCaseDiagram](https://user-images.githubusercontent.com/62339676/197333633-46ff9ed8-137f-4a6b-8b57-3e35bdc309aa.png)
  
### 4.1 Use-Case Realizations

Our user starts on our landingpage, where he can choose between joining a "Quickgame" (where he will be moved into any public session with enough space for one more player), joining a private game (where he has to enter a code to enter the lobby) and creating a new game with the attributes he wishes to use. When creating a new game, the user can modify settings such as the time for answering, the amount of questions asked and the player capacity of his lobby. After creating a game or joining a game the user enters a lobby which leads into the game itself, where questions are to be answered, points can be collected for the answers given by the users and in the end the results are displayed.

You can find specific UCRs in our "docs" folder. 

## 5. Logical View
 
 ### 5.1 Overview
 
The program consists mainly of 3 subsystems named after their classes: RoomController, PlayerController and GameController. 
The RoomController is responsible for the room/lobby in which the players are located. A player creates or joins a room. As soon as a room is filled and the game has been started by the host, the PlayerController and GameController are used. The GameController manages all operations of the game, such as managing modes and rounds. The PlayerController communicates directly with the GameController and exchanges the data of the individual players depending on the game status. It also manages the respective player answers.
 
 ### 5.2 Architecturally Significant Design Packages
 
 On this section you can find our class diagram.
 
![Class-Diagram](https://user-images.githubusercontent.com/62339676/199744380-08408e17-e07b-4db5-bb9d-62a1bb99b51e.jpg)
 
## 6. Process View

It is differentiated between the following Heavy Weight Processes: Start Game, New Round, Compare Answer, Get Result. The Start Game process is called at the start of a game and initializes the game. Afterwards, this calls the Start Round process. This assigns all player variables and retrieves a question via a GET requester by the Light Weight Process Generate Question Process. Subsequently, the Compare Answer process causes the answers to be sent to the host to compare them there. The Get Result process stores all results, synchronizes it with all players and outputs it to the UI.

![Sequence Diagram](https://user-images.githubusercontent.com/62339676/206184580-403996cd-29e9-433d-9bfd-f603d879860b.png)


## 7. Deployment View

Three components are used for a complete game: Server, Master, Clients. The server runs at the PhotonServices and stores all rooms and corresponding player information.
A master player is also required. This creates a room and then manages it. He is also responsible for the gameplay and the choice of questions. 
The third component is the player clients. They are responsible for their own answers and send them to the master. Every communication takes place via
the server (photon) instead. As soon as the master receives the answers, he compares them and then sends the respective score back to the players.

![DeploymentDiagram](https://user-images.githubusercontent.com/62339676/206647175-6c4f88b0-94f8-4c94-a943-fea3176c70e4.png)


## 8. Implementation View

### 8.1 Overwiev

(n/r)

### 8.2 Layers

(n/r)

## 9. Size and Performance

We plan to have a maximum total user capacity of 20 at a time. There must be at least one user in each lobby (gameroom) and a maximum of eight users can be in the same lobby. The amount of gamerooms at a time is not limited itself but indirectly by the total user capacity.

Because of those limitations each lobby is closed after the match is done, all users return to the main landingpage. This way, no users can occupy the resources permanently, so that everyone can play at some point.

Therefore we agreed on other limitations:
The maximum time to answer one question is set to 90 seconds. Per match, up to 15 questions are available to be answered. 

## 10. Quality

The event driven architecture (mediator topology model) helps us in other aspects than functionality as well. The mediator topology enables us to easily change settings, for both the game in general and for users. Also, users can theoretically join a running round and leave a running round without causing any problems to the game itself. Our game benefits greatly from this, especially because of gains in the area of reliability. 


