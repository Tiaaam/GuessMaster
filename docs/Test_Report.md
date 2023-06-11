# Test Report Document

## Table of contents

- [Table of contents](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#table-of-contents)
- [Introduction](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#1-introduction)
- [Test Strategie](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#2-test-strategie)
- [Test Plan](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#3-test-plan)
- [Test Cases](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#4-test-cases)
- [Test Results](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#5-test-results)
- [Metrics](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#6-metrics)
- [Recommendations & Conculsion](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Test_Report.md#7-recommendations--conclusion)



## 1. Introduction

This section provides an overview of the software testing process and the scope of the testing activities. The primary objective of testing GuessMaster is to ensure the quality and reliability of the game by thoroughly assessing its functionality, performance, and user experience. By conducting systematic and comprehensive testing, we aim to identify and rectify any defects or issues that may hinder the game's performance or user satisfaction.

The scope of our testing activities includes examining the significant functions that directly impact gameplay. This encompasses testing various gameplay scenarios, evaluating user interactions, and assessing the accuracy and relevance of the question and answer components. Additionally, we will focus on tracking important files necessary for maintaining the integrity of the game's question and answer database.

## 2. Test Strategie

This section describes the overall approach to testing, including the testing methodology, testing types, and testing techniques used. For GuessMaster, we have adopted a comprehensive test strategy that combines manual and automated testing approaches. Unfortunately, we cannot use the Unity testing framework to test our Photon hosting service because it is not compatible. To cover this part of our software we will do manuell tests and see if everything works like it should. 

### Testing Methodology:
- Our testing methodology follows a structured and systematic approach. We focus mainly on functional testing so that we can ensure that our game works properly

### Testing Types: 
- Functional Testing: This focuses on validating the game's functionalities, ensuring they operate as intended and meet the specified requirements (Unit Tests)
- manual tests 

## 3. Test Plan

- Test-types: Unit Testing, manual tests
- Target-Test-Coverage: every newly added major function (Smoke testing), 20% (Unit Testing)
- Testing-Tool: Unity Test Framework
- Manage-Test-Cases: Internal Unity test manager; through manual code exchanges different deplyoment versions can be tested

## 4. Test Cases

### Test 1

- Here we check if the CSV file responsible for the questions & answers is present in the resource folder

![image](https://github.com/Tiaaam/GuessMaster/assets/62339676/df719a81-a2b3-4175-92e8-5809712e7538)

### Test 2

- We do manuell tests 


## 5. Test Results

Based on our subdivision and tests with the Unity Testing framework, we were able to achieve the following results for the individual tests:

- Test 1: Passed 2/2 tests -> Test-Coverage: 100%

![image](https://github.com/Tiaaam/GuessMaster/assets/62339676/2686dbf6-68b3-4674-af87-f93bd1037b0a)

- Test 2: It passed all our manuell tests, otherwise our game wouldnt work. 

## 6. Metrics

The functionalities we tested achieved a test coverage of: 100%. 

> However, this metric should only be viewed in relative terms, as we did not cover the entire game with the tests, but only some components.

## 7. Recommendations & Conclusion

With our manual tests and with the help of the unity test framework we were able to test some parts of our game. As already mentioned, the obtained test coverage should be considered only relatively, since we tested only a small part by software and a larger part manually, since the Unity Testing Framework is not compatible with our hosting service photon.



