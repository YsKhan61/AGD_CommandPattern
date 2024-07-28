# Wizard Fight

  A mini-game where various wizards with their specific abilities can fight with each other.
  It is a turn-based game, played by two people on the same device.

# Code architecture
  * Command Pattern - It helps to create undo and redo mechanics for the player's action.
  * Flyweight Pattern - Scriptable Object assets share the common data among all the entities and other objects that need them.
      Eg: UnitScriptableObject, PlayerScriptableObject
  * Service Locator - This design pattern helped to communicate between different modules of the project through a single service locator.
      Eg: PlayerService, BattleService, ActionService, UIService, SoundService etc. connected through GameService.
  * Observer Pattern - This helps to notify the listeners of different modules once an event of a publisher has been invoked.
  * Singleton Pattern - This helped in easy access of only a single instance of a certain class for global access.
  * Model-View-Controller - Certain UI scripts are separated in this architecture.

# Screenshots
  ![Screenshot 2024-07-28 132900](https://github.com/user-attachments/assets/400962e6-716f-4b99-b448-2c83d66b2432)
  ![Screenshot 2024-07-28 132934](https://github.com/user-attachments/assets/e1490897-7745-4bd4-92b1-c991dd89e9f4)
  ![Screenshot 2024-07-28 133009](https://github.com/user-attachments/assets/e1db2a39-9c12-46d4-984d-cf1afae2cba8)
