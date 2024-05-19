## Text Trainer Program

### Overview:
The Text Trainer program is designed to help users improve their typing accuracy and speed through interactive training sessions. It provides various difficulty levels, customizable training sessions, and performance statistics.

### Features:
1. **Training Sessions:**
   - Users can participate in training sessions where they are presented with random text snippets to type.
   - The difficulty level of the training sessions can be customized based on the number of words to type.
   - Training sessions are interactive, allowing users to type the presented text in real-time.

2. **Accuracy Calculation:**
   - The program calculates the accuracy of the user's typing based on the correctness of the typed characters compared to the expected text.
   - Accuracy is displayed to the user during and after each training session.

3. **Performance Statistics:**
   - Users can view detailed statistics about their training performance, including average training time, best and worst accuracy achieved, and total training sessions completed.
   - Statistics provide insights into the user's progress and areas for improvement.

4. **Observer Pattern:**
   - The program utilizes the Observer design pattern to notify observers (such as the console) when a training session is completed.
   - Observers receive messages indicating the completion of training sessions.

5. **Training Result Management:**
   - Training results, including start time, end time, and accuracy, are managed and stored by the program.
   - Users can choose to save training results to a file for future reference.

6. **Text Provider:**
   - The program retrieves random text snippets from a predefined set of texts to present to users during training sessions.
   - Texts cover a wide range of topics to keep training sessions varied and engaging.

### Usage:
1. Launch the Text Trainer program.
2. Choose the desired difficulty level for the training session.
3. Start the training session and type the presented text as accurately and quickly as possible.
4. After completing the session, review the accuracy and performance statistics.
5. Optionally, save the training results to a file for future reference.
## Programming Principles
### Single Responsibility Principle (SRP):
Each class and method has a single responsibility. For example, TrainingSession handles the logic of a training session, while TrainingResultManager handles the storage and retrieval of session results.
### Open/Closed Principle (OCP):
Classes are open for extension but closed for modification. The use of interfaces and strategy pattern allows for easy extension of functionality without modifying existing code.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/IAccuracyCalculationStrategy.cs#L9-L12
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/BasicAccuracyStrategy.cs#L9
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/AdvancedAccuracyStrategy.cs#L9
### Dependency Inversion Principle (DIP):
High-level modules should not depend on low-level modules; both should depend on abstractions. For example, TrainingSession depends on IAccuracyCalculationStrategy, an abstraction.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/TrainingSession.cs#L10-L12
### Interface Segregation Principle:
The IAccuracyCalculationStrategy interface has only one method, CalculateAccuracy, allowing classes to implement only the necessary functionality without imposing unnecessary methods.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/IAccuracyCalculationStrategy.cs#L9-L12
### Don't Repeat Yourself (DRY)
Avoiding code duplication can be observed in methods that perform similar actions and can be abstracted into separate methods or classes to avoid code repetition. For example, if there are repeated blocks of code for calculating accuracy, these blocks can be extracted into separate methods or classes that can be called in different parts of the program.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/AdvancedAccuracyStrategy.cs#L14-L31
## Refactoring Techniques
### Extract Method
Extracting logic into smaller, reusable methods helps make the code more readable and maintainable.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/TrainingResultManager.cs#L79-L98
### Replace Magic Number with Symbolic Constant:
Instead of using raw numbers, i use enums for readability and maintainability.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/TrainingDifficultyManager.cs#L9-L14
### Simplify Conditional Expressions
Simplifying nested or complex conditionals into more readable forms.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/Program.cs#L17-L29
### Extract Interface
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/IAccuracyCalculationStrategy.cs#L9-L12
### Move Method
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/TrainingSession.cs#L29
## Design Patterns
### Strategy Pattern
The strategy pattern is used to define a family of algorithms, encapsulate each one, and make them interchangeable. The IAccuracyCalculationStrategy interface and its implementations (BasicAccuracyStrategy and AdvancedAccuracyStrategy) exemplify this pattern.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/IAccuracyCalculationStrategy.cs#L9-L12
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/BasicAccuracyStrategy.cs#L9
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/AdvancedAccuracyStrategy.cs#L9
### Singleton Pattern
Ensures a class has only one instance and provides a global point of access to it. The TextProvider class is implemented as a singleton.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/TextProvider.cs#L9C4-L97C1
### Observer Pattern
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified. The EventNotifier class implements this pattern.
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/IObserver.cs#L9-L12
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/ISubject.cs#L9-L14
https://github.com/ZarembYehor/KPZProject/blob/894f620a87cc99ab4140ccb065cb896bb78b925e/TextTrainer/ConsoleApp1/EventNotifier.cs#L9-L32
