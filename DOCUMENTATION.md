# Template Documentation

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

### Weapon SO
Weapon scriptable object contains info about weapon and prefab for weapon. These informations are loaded in other scripts.


## Player scripts
Scripts attached to player that handle base game mechanics.

### Movement
Movement script manages actions of Player. Following script is dependand on many other scripts and game objects.

List of referenced scripts:
* PlayerStats
* ItemHolder
* Item
* Stamina
* Player Health

List of referenced game objects:
* weaponPointAnimator
* weaponAnimationPoint
* Rigidbody2D
* playerAnimator
#### Movement logic
Script is devided into multiple parts. First part in fixed update is handling of movement conditions. Movement speed of player is changed based on coditions.
```
        else if (isHealing)
        {
            Rigidbody2D.velocity = movementDirection * slow;

        }
```
In this example players movement speed is slowed if player is healing. All movement speed altering logic is handled here.

#### Action condition logic

Second part of this script handles inputs through button inputs. If all conditions for specific action are met then code will execute coresponding action.

```
        if (Input.GetKeyDown(KeyCode.R) && !isRolling && !isHealing && !action) //heal
        {
            StartCoroutine(HealCoroutine());
        }
```
Example of healing logic. Where if all conditions are met then HealCoroutine will be executed.

#### Action logic

Last part of the script is executed actions logic.  These are fucntions that are called when input.

```
    private IEnumerator HealCoroutine()
    {
        playerAnimator.SetTrigger("HealTrigger");
        action = true;
        isHealing = true;
        yield return new WaitForSeconds(1f);
        PlayerHealth.PlayerHealValue();
        isHealing = false; 
        action = false;
    }
```
Example of heal coroutine logic that will be called in iput conditions.


### Player Health
Health script contains one float variable that is derived from [scriptable object](#scriptable-objects) of any entity and its children at start This Script also contains healthbar slider for visualisation of health of entity.
Player Health script extends regular health scrip. Additional functions of this script are handling of heal charges used for player healing and linking that with coresponding UI element.

When game is quit player's current health are saved with SavaData function form

### Player Stamina
Player stamina script handles player's stamina. Stamina in this template is used for following actions:
* Attack
* roll 
* sprint

Script contains function ConsumeStamina that has parameter of consumend stamina when called in scripts such as Movement.

Second functions is StaminaDrain. If script's boolean drainStamina is set to true then function will continuously drain players stamina.

Third function is StaminaRegen. If script's boolean drainStamina is set to false and ConsumeStamina hasnt been called for some time then function will continuously regenerate players stamina so it can be used again.

### Item holder
Item holder serves as inventory for player where he has all items stored so his inventory can be managed in one place. In this template this item holder is used only for weapons.

Script has two functions. First is SwapWeapon which based on functions parameter that is id of a weapon we want to change to will replace Players child in transform with selected weapon. These weapons are prefabs.

Second function is AddItem that passes scriptable object to add to list of items, in our case weapons.

## Players children scripts

Scripts that are on child gameobjects of a Player.

### Cursor Rotate 
Cursor rotate is for making referenced weapon to rotate towards mouse position.

### PLayer Damage
Script for handling damage passed from Player's weapon to enemy entity. Stats of a weapon are loaded at start or when 
item holder script swaps weapon through SwapWeapon function.

Damage passing is handled through Unity's native function OnTriggerStay2D. Damage will be passed only if triggered collider has tag of a Enemy. Conditions for this are also altered in Movement.


## Enemy Scripts

These scripts are mainly used on scripts that affect the way enemies and its children such as weapons.

### Health
Script for simple health logic of entities this scripts is extended by player health. Script has reference to health bar ui component that it updates whenever health value in script is changed.
Script has Heal Function that as parameter has value of heal recieved to holder of health script.

### State Manager
Script for handling of behaviour of enemy entity. It uses public scripts for specific behaviour and changes states of behaviour of Enemy.
Scipts that are used in this template are:
* Chase Script - Chasing passed transform as parameter. Used on Player.
* Patrol Script - Patroling between an array of weaypoints on repeat.
* Combat Script - Using animator of Enemy and triggering attack animation.
* Passive Script - Keeping distance from passed transoform.

## Enemy children Scripts

### Weapon Rotate 
Weapon rotate scripts set rotarion of weapon so that is faces opposite of referenced player.

### Enemy Damage

Script handling passing damage form Enemies weapon to player.


## General Scripts
Scripts for smaller things in template such as camera, Ui toggiling.

### Camera Follow

Script that has public transform that it follows.

### Item Info

Item info is used on pickupable items in scene. Script only holds content of item that will be picked up. Context of item is in scriptable object that is Weapon.

### Profile Manager


### Damage Area

Damaging area over time. Only on player. Used for simple testing.
### Heal Flask Refill

On entering simple collider players heal charger will be reffiled to 20. Used for simple testing.

### Menu Handle
Toggles menu and inventory interface. Through specific binds will simply togge inventory or menu Ui elements.

### Profile Manager
Manages profile loading and saving in Game scene. Upon entering screne sets player scriptable object with data to coresponding profile by id. If game is quit then it will rewrite profiles data and upload.


<!--
Scripts that are attached to player:

* [Player Input](#player-input)
* [Player Movement](#player-Movement)
* [Player Heal](#player-heal)

-->




## Inventory system and UI
Inventory system and its ui manage items of player. Here user can interact  with ui and it will set corespoding items to him in game.

### Load items
When category of items is clicked script will render all items player has in Item holder script.

## Saving Data
Scripts for handling persisten data. These data are saved in assets so can be accessed between



## Profile Handling
Scripts for managment of profiles across scenes.
#### SelectProfile
Finalizes profile creation in Main menu profile creation section. If name input in not empty will create profile with input as name and profile preset scriptable object on button. Profile presets are stats for beggining profiles. In project health, stamina and strenght are examples. Created profile is parsed to json format and saved in Assets/Profofiles folder.

## Main Menu Scripts

Scripts handeling logic of Main Menu scene.
### Main menu button functions
Manager for most of specific buttons in Main menu scene. All buttons in title screen use this script for on click functions.
Return - returns from specific screen back to title screen.
Load Game - loads game if profile id isnt 0.
Render Profiles - renders all profiles into character selection screen.
New Profile - opens profile creation screen.
### Profile Information
Class for formating profile structure. Data used as example in template are name, id, health, stamina, strenght, location
### Select profile
In profile selection screen saves id of clicked profile button

## Assets
All assest in this template are made by me in web software Figma. These Vector graphics are free to use.
