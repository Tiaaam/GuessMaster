## CI / CD Setup - Problems

Unity apparently isn't supposed to work with any CI/CD tools. We're not willing to pay for their solution (Unity Build Automation) though, which in turn means that we simply cannot use CI/CD correctly.

Details, why we cant gain any benefits:
- building the application: cannot be done by any command-prompts. We need to build our application in Unity.
- running tests: our tests need to be started manually in the Unity Testing Framework. 

## Certain Measures 

- We'll run our tests before pushing changes onto our GitHub (this way, even without CI/CD pipeline, we can ensure that our game works correctly)
