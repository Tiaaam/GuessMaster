# Architecture Significant Requirements (ASR)

## 1. Utility tree

Here you can get access to our [Utility tree](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Utility%20tree.xlsx).

## 2. Architecture decisions and Concrete design patterns

Here are some ouf our thoughts that influenced our priorities in the Utility tree that are important:

### Availability:
- Photon (Hosting Service used for playermanagement)
- APIs (Used to create questions and answers)

With one of them not working GuessMaster cannot be played. (high business value)

### Modifiability (in our case: settings):
- gamemode modifications (e.g. time to answers, amount of rounds ...)

Important for user satisfaction. Standard values probably aren´t optimal for everyone, players might stop guessing. (high business value)

### Peformance:
- Waitingtime between questions / answers / score - updates as short as possible
- enough performance for 20 players at a time 
- minimise downtime caused by external circumstances

Important for user satisfaction. Unnecessarily wasted time might demotivate players. On one hand we don´t want users to not be able to play but we can´t cover the costs for more than 20 players at a time. That fact is dependet on our Hosting Service Photon allowing us to host a game / games with max 20 players combined for free. 

### Usability:
- easy-to-use UI

Important for user satisfaction. (high priority)

Based on these points and our understanding of our tolls we decided that an Event-Driven-Architecture would suit these goals best, specifically the Mediator topology model. We realised that user satisfaction is extremely important for our project. Therefore we set usability und performance as our main architecture decisions.

That gets us to the following design patterns:

- 
