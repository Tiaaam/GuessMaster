# Studied metric - Relation Among Classes

- "Relation among classes" is a metric that describes the relationship between classes. 
- It takes the "depth of the inheritance tree" (DIT), the "number of children" (NOC), the "method inheritance factor" (MIF) and the "response for a class" (RFC) into account.


### Depth of the inheritance tree (DIT)

- A class's DIT shows how many steps there are between it and the main class. If a class has a higher DIT value, it could mean a more intricate and possibly more difficult-to-manage hierarchy of classes.

### Number of children (NOC)

- NOC indicates the number of direct subclasses a specific class has. A high NOC can indicate a complex class hierarchy that may be difficult to understand and maintain.

### Method inheritance factor (MIF)

- MIF measures the proportion of inherited methods compared to the total number of methods of a class. A higher MIF value means that a class inherits a significant portion of its functionality from parent classes, which could mean that it is tied to its parent class too strongly, while a low MIF can mean that this class is overloaded.

### Response for a class (RFC)

- RFC represents the number of methods that can be directly or indirectly called by the class. A high RFC value indicates that the class has many dependencies and is therefore probably very complex

# Our Metrics

For GuessMaster, we decided to use DIT, NOC and cyclomatic complexity. We can calculate them as follows:

### DIT & NOC: 
  -  We're trying to keep it all (including our classes) simple and maintain low complexity. 
  -  We can calculate DIT by counting the (direct and indirect) parent classes of a class and NOC by counting each classes direct subclasses.
 
 ### cyclomatic complexity: 
 - Just as with DIT and NOC, we want to evaluate our code's complexity with cyclomatic complexity.
 - It can be calculated by using a control flow path with the following formula: E - N + 2P
 
   > where "E" stands for the number of edges of the graph, 
   > "N" stands for the graph's nodes 
   > and "P" stands for the number of connected components. 

## Summary 

At the end of our project we were able to achieve the following metrics. The selection of these metrics gives concrete information about the complexity of our source code.

- DIT: 1
- NOC: 1
- cyclomatic complexity: ?


