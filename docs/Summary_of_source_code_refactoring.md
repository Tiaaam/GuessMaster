# Summary of source code refactoring

## Table of contents

- [Table of contents](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#table-of-contents)
- [Refactorings](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#1-refactorings)
  - [Comments](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#11-comments)
  - [Style](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#12-style)
  - [Duplicate Code](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#13-duplicate-code)
  - [Classes](https://github.com/Tiaaam/GuessMaster/blob/master/docs/Summary_of_source_code_refactoring.md#14-classes)

## 1. Refactorings

### 1.1 Comments
The source code had multiple instances of outdated code inside of long comments. 
Those comments have been removed to make the source code more readable.

### 1.2 Style
The naming conventions for variables, functions and classes weren't the same everywhere in the source code. For example, we decided to remove any "_" at the start of private variables or methods.
The names of a few variables were changed to to make the names more uniform.
Redundant empty lines were removed as well.

### 1.3 Duplicate Code
There were instances in the source code where the same code needed to be executed by a common client and by the master client. 
Those intances of duplicate source code were refactored to new functions which replaced the duplicate code.

### 1.4 Classes
"CountdownTimer" was a bad name for a class, because it didn't really explain it's function correctly. The class was renamed to "RoundController".
