# GuessMaster - Software Requirements Specification

## Table of contents

- [Table of contens](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#table-of-contents)
- [Introduction](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#1-introduction)
  - [Purpose](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#11-purpose)
  - [Scope](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#12-scope)
  - [Definitions, Acronyms and Abbreviations](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#13-definitions-acronyms-and-abbreviations)
  - [References](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#14-references)
  - [Overview](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#15-overview)
- [Overall Description](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#2-overall-description)
  - [Vision](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#21-vision)
  - [Use Case Diagram](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#22-use-case-diagram)
  - [Technology Stack](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#23-technology-stack)
- [Specific Requirements](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#3-specific-requirements)
  - [Functionality](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#31-functionality)
  - [Usability](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#32-usability)
  - [Reliability](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#33-reliability)
  - [Performance](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#34-performance)
  - [Supportability](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#35-supportability)
  - [Design Constraints](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#36-design-constraints)
  - [Online User Documentation and Help System Requirements](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#37-online-user-documentation-and-help-system-requirements)
  - [Purchased Components](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#38-purchased-components)
  - [Licensing Requirements](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#39-licensing-requirements)
  - [Legal, Copyright And Other Notices](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#310-legal-copyright-and-other-notices)
  - [Applicable Standards](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#311-applicable-standards)
  - [Specitifc Requirements](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#312-specitifc-requirements)
- [Supporting Information](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SoftwareRequirementsSpecification.md#4-supporting-information)
  
 
## 1. Introduction

### 1.1 Purpose

This Software Requirements Specification (SRS) describes all specifications for the application “GuessMaster”. It includes an overview about this project and its vision, detailed information about the planned features and boundary conditions of the development process.

### 1.2 Scope

The project is going to be realized as a web application.

### 1.3 Definitions, Acronyms and Abbreviations

| Abbrevation | Explanation                            |
| ----------- | -------------------------------------- |
| SRS         | Software Requirements Specification    |
| ·WIP·       | Work in Progress                       |
| n/r         | not required                           |

### 1.4 References

| Title                                                              | Publishing organization   |
| -------------------------------------------------------------------| ------------------------- |
| [GitHub](https://github.com/Tiaaam/GuessMaster)                    | GuessMaster Team          |

### 1.5 Overview

In the next chapter we will give you an overview of our vision and our Use Case Diagram. Furthermore you will get tho know more about the technology we use. The third chapter (Specific Requirements) provides more details about the Functionality, Usability and more. And last but not least you can find more helpful information about the project.

## 2. Overall Description

### 2.1 Vision

Our goal is to create a fun game to connect with others. We plan to make a web-based mini-game. Various questions are to be answered and the players receive points depending on their answers.

### 2.2 Use Case Diagram

![UseCaseDiagram](https://user-images.githubusercontent.com/62339676/197333633-46ff9ed8-137f-4a6b-8b57-3e35bdc309aa.png)

### 2.3 Technology Stack

The technology we use is:

| Section            | Technology                             |
| ------------------ | -------------------------------------- |
| Backend            | Unity                                  |
| Frontend           | Unity                                  |
| IDE                | Visual Studio 2022                     |
| Project Management | Azure DevOps, Github                   |
| Testing            | ?                                      |


## 3. Specific Requirements

### 3.1 Functionality

In this subsection, we will explain the different Use Cases with the associated functionalities. The individual Use Cases can be taken from the Use Case Diagram in 2.2.

Until the End of Semester 4 we plan to implement:

- 3.1.1 Gamemode Selection
- 3.1.2 Settings
- 3.1.3 Lobby System
- 3.1.4 The Game itself

#### 3.1.1 Gamemode Selection

This feature is very important for the project as it represents the different ways for a user to enter a game. It is possible to join a public or private game. However, the user has the option to directly create a game by themself too.  

[Gamemode Selection](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SRS_Gamemode_Selection.md)

#### 3.1.2 Settings

If the user chooses to create a game, they have the option to configure multiple aspects like number of rounds, number of players and more. This feature directly affects the properties of the game.

[Settings](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SRS_Settings.md)

#### 3.1.3 Lobby System

To play a game with multiple users, it is nesseacry to implement a system, which allows the users to join the same lobby. This feature works as a waiting room until the creator of the lobby starts the game.

[Lobby System](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SRS_Lobby_System.md)

#### 3.1.1 The Game itself

In the game a question is displayed and the user has a specific amount of time to submit an answer. A correct or close answer is worth a certain amount of points getting saved and displayed in a scoreboard until the end of the game.

[The Game itself](https://github.com/Tiaaam/GuessMaster/blob/master/docs/SRS_Game.md)

### 3.2 Usability

We intend to implement GuessMaster as well as possible in order to achieve a high level of user satisfaction. Therefore, we have decided to run GuessMaster as an online service, so that the user does not need to install any additional software to play the game. Getting into a game, starting your own game and playing itself should be made intuitive and self-explanatory by the user interface


### 3.3 Reliability

The availability of GuessMaster depends on external components. On the one hand, to be online we are dependent on our hosting service Photon. On the other hand, we are dependent on various API services for the creation of the questions and answers. 

Of course we want to keep the availability of GuessMaster as high as possible, so we regularly check the availability of the external components through our system.

If you encounter any problems, please contact us.

### 3.4 Performance

Because GuessMaster is a simple 2D-WebGame, the overall system requirements are low. We intend the game to be available for a maximum of 20 players at a time and our services should run smoothly under this condition.
Meaning: 
- Waitingtime when creating a lobby should be <1.5 seconds
- Waitingtime between questions/answers/score-updates must not excel 1.5 seconds

### 3.5 Supportability

GuessMaster's code is easily understandable for anyone who knows his way around the tools we use. We use speaking names for our variables, funtions and scipts where possible.

### 3.6 Design Constraints

·WIP·

### 3.7 Online User Documentation and Help System Requirements

As the game is supposed to be self-explanatory, we will include a help-option in the game itself, which will explain the basics. These instructions will also be uploaded here on GitHub in a seperate document, which will be linked down below (once available).

The GuessMaster-team will be reachable on GitHub and Discord for further assistance and support requests.

·WIP·

### 3.8 Purchased Components

We don't have any purchased components yet. If there will be purchased components in the future we will list them here.

### 3.9 Licensing Requirements

(n/r)

### 3.10 Legal, Copyright And Other Notices

CC BY-NC-SA 4.0

We do not take responsibilty for any incorrect data or errors in the application.

### 3.11 Applicable Standards

The development will follow the common clean code standards and naming conventions.

### 3.12 Specific Requirements

(n/r)

## 4. Supporting Information

For any further information you can contact the GuessMaster Team or check out our weekly blog post on discord. 
