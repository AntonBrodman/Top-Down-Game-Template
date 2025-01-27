# Template Documentation

## General scripts and functions
General scripts and functions contains functionalities that should be easily applied.

### Health
Health script contains one float variable that is derived from [scriptable object](#scriptable-objects) of any entity and its children at start This Script also contains healthbar slider for visualisation of health of entity.

### Damage Handle   <!--unfinished-->

Damage handle is a simple script for passing demage value of referenced [scriptable object](#scriptable-objects) to a entity with [Heal script](#health) when collision occurs.

## Scriptable objects
Most of constants are saved in scriptable objects. Scripts that fetch values from scriptable objects are set at start so they can be latter accesed individually and changed without altering values of scriptable object. 

### Entity stats
Main scriptable object for simple entities that contains only information about name of entity and health. This scriptable object serves as base for more complex scriptable objects.

Entity stats serves as parent for two other scriptable objects.

### Enemy stats
Enemy stats serves as an extention of entity stats scriptable object. 

This script contains following variables:

* Patrol speed 
* Chase speed 
* Attack distance
* Physical resistance

### Player stats
Player stats is another extention of entity stats scriptable object.

This script contains following variables:

* Movement speed
* Dodge speed
* Duration of dodge
* Cooldown on dodge action
* Cost of dodge action
* Duration of heal action
* Value of heal action
* Speed of player during heal action


### Attack stats
Attack stats is scriptable object to keep track of info about different attaks. Scriptable object contains 

### Weapon SO
Weapon scriptable object contains info about weapon and prefab for weapon. These informations are loaded in other scripts.
### Weapon SO
Armor scriptable object contains info about armor. These informations are loaded in other scripts.


## Specific scripts and functions
These are funtionalities that are for specific cases and cannot be applied generally. For example script for some specific ai or player abilty are type of this script.

### Player related scripts
These are scripts that are attached on player and affect events connected to him.

Scripts that are attached to player:

* [Player Input](#player-input)
* [Player Movement](#player-Movement)
* [Player Heal](#player-heal)

#### Player Input
Player input handles inputs of player. All actions by player should be catched here and in Player Movement. Player input handles all non movement inputs, even if player action affects movement of player this action is here.

Functions that Player Input handles are:

* Heal action
* Attack action

#### Movement
Player movement handles input of movements and actions such as heals, attacks, interactions. Into movements counts basic WSAD movement and dodge ability binded on key B. There are other functions that alter movements, but they are in [Player Input](#player-heal). 

#### Player Heal
Player heal is function for passing values between [stats of player](#player-stats) and its [health](#health). Function also takes some time and player is slowed for set time. All values are fetched from [Player stats](#player-stats).
#### Cursor Rotate 
Cursor rotate is for making referenced weapon to rotate towards mouse position.
#### Player Stamina
Player stamina is function that on specific player action drains stamina and regenerates it if no action was made for specfit set of time. If player does not have enough stamina then action will not be performed.
### Enemy related scripts
These scripts are mainly used on scripts that affect the way enemies and ist children such as weapons.

#### AiBehaviours   <!--unfinished-->
Ai behaviours script is an algorith that sets the way ai behaves. Scripts contains states of passive, chase, follow, idle and patrol mode.  

#### Weapon Rotate 
Weapon rotate scripts set rotarion of weapon so that is faces opposite of referenced player.
## Assets
All assest in this template are made by me in web software Figma. These Vector graphics are free to use.

## Inventory system and UI
Inventory system and its ui manage items of player. Here user can interact  with ui and it will set corespoding items to him in game.
### Menu Handle
Toggles menu and inventory interface.
### Load items
When category of items is clicked script will render all items player has in Item holder script.
### Item holder
Item holder serves as inventory for player where he has activa and all items stored so his inventory can be managed.
### Open Inventory <!--not used-->
open inventory serves as functions for buttons in inventory ui. this script has two types of buttons. Ones that call render of all items, and others when clicked in this newly generated grid will equid coresponding item to player in scene.
## Saving Data
Scripts for handling persisten data. These data are saved in assets so can be accessed between
## Profile Handling
Scripts for managment of profiles across scenes.
#### SelectProfile
Finalizes profile creation in Main menu profile creation section. If name input in not empty will create profile with input as name and profile preset scriptable object on button. Profile presets are stats for beggining profiles. In project health, stamina and strenght are examples. Created profile is parsed to json format and saved in Assets/Profofiles folder.
#### Main menu button functions
Manager for most of specific buttons in Main menu scene. All buttons in title screen use this script for on click functions.
Return - returns from specific screen back to title screen.
Load Game - loads game if profile id isnt 0.
Render Profiles - renders all profiles into character selection screen.
New Profile - opens profile creation screen.
#### Profile Information
Class for formating profile structure. Data used as example in template are name, id, health, stamina, strenght, location
#### Profile Manager
Manages profile loading and saving in Game scene. Upon entering screne sets player scriptable object with data to coresponding profile by id. If game is quit then it will rewrite profiles data and upload.
#### Select profile
In profile selection screen saves id of clicked profile button