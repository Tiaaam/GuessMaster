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
- ·WIP·

Logical View:
- The program consists mainly of 3 subsystems named after their classes: RoomController, PlayerController and GameController. 
The RoomController is responsible for the room/lobby in which the players are located. A player creates or joins a room. As soon as a room is filled and the game has been started by the host, the PlayerController and GameController are used. The GameController manages all operations of the game, such as managing modes and rounds. The PlayerController communicates directly with the GameController and exchanges the data of the individual players depending on the game status. It also manages the respective player answers.

Process View:
- It is differentiated between the following Heavy Weight Processes: Start Game, New Round, Compare Answer, Get Result.
The Start Game process is called at the start of a game and initializes the game. Afterwards, this calls the Start Round process.
This assigns all player variables and retrieves a question via a GET requester by the Light Weight Process Generate Question Process. Subsequently, the Compare Answer process causes the answers to be sent to the host to compare them there. The Get Result process stores all results,
synchronizes it with all players and outputs it to the UI.

Deployment View:
- ·WIP·

Implementation View:
- ·WIP·


## 3. Architectural Goals and Constraints

We saved our Architectural Goals and Constraints in the [Architecture Significant Requirements (ASR)](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Architecture_Significant_Requirements.md).

## 4. Use-Case View
  
### 4.1 Use-Case Realizations

·WIP·

## 5. Logical View
 
 ### 5.1 Overview
 
 ·WIP·
 
 ### 5.2 Architecturally Significant Design Packages
 
 ·WIP·
 
## 6. Process View

·WIP·

## 7. Deployment View

·WIP·

## 8. Implementation View

### 8.1 Overwiev

·WIP·

### 8.2 Layers

·WIP·

## 9. Size and Performance

·WIP·

## 10. Quality

The event driven architecture (mediator topology model) helps us in other aspects than functionality as well. The mediator topology enables us to easily change settings, for both the game in general and for users. Also, users can theoretically join a running round and leave a running round without causing any problems to the game itself. Our game benefits greatly from this, especially because of gains in the area of reliability. 

