# FaeFolk

16x16 sprite NES-inspired art. 2D topdown pixel art.

## Game Design Document

### Concept

- Community life sim
  - Collect and discover things (core)
  - Build relationships with others over time
  - Earn money and expand your assets
  - Personalize your space and beautify the land

### Game Overview

- Main menu screen -> play game, settings (reset game, volumes, etc), quit
- Explore the town and engage in activities (daily, seasonal, etc)
  - Player can walk around town, use tools and items, and interact with objects and people
  - NPCs follow daily routines, buy and sell, and interact with Player
  - The land is affected by time like time of day, season, growing, and buried items
- Save and quit

### Game Design

**Theme**: Community life sim
**Player Experience:** Relaxing and welcoming
**Core Mechanic:** Free-style activities to collect items, earn money, decorate, and build bonds.
**Game Loop:** Daily world progression introducing a rolling stream of content (collectables, NPC chats, etc)

### Feature Analysis

#### Core

The player can login each day and collect plants (fruit, flowers), critters, and fish.
They can gift items to NPCs to increase bond and learn new factoids about each, expanding your encyclopedia.
Players can develop NPC relationships over time with interactions

World - seasons, time of day, weather, plants
Player - movement, interact, collect items

#### Secondary

Players can buy and sell items.

#### Polish

Menus
Music, SFX
Extra content, fine-tuning

### Art Assets

- Player/NPCs (creatable)
- Tileset (Ground, water, etc)
- World objects (plants, trees, rocks, buildings)
- Indoor tileset/objects
- Pickup items
- UI borders, fonts, etc.

## NPC System Ideas

Emoji wheel can trigger interactions within a range/cone of sight/sound

- wave hi/bye
- joy
- surprise
- worry
- cry/sadness
- afraid
- question/curious
- angry
- sleepy
- laugh
- sorry
- agree
- shake head
  NPCs show dialogue bubbles when close and player is still.
  Dialogue switches and shrinks to 'portable bubble' when player is moving or far.
  NPCs may keep talking and follow the player if the conversation hasn't ended and they can move freely.
  Available interaction options are readily available in a wheel or strip at the top and change on the fly during conversation.
  Waving goodbye ends conversations.
  Some interactions only happen during specific activities like when seated next to the NPC, playing together, etc.
  All interactions are an emoji icon combined with a label.
- emotion reactions
- people
- locations
- times, weathers, etc.
- items
  More complex interactions can occur by combining emojis like:
- person 1 emoji + anger emoji + person 2 emoji will ask an NPC 'why is person 1 angry at person 2?'

## Summary of MVP Milestone 1

- Player opens game to see NPC ask if you want to move out and live in a new town.
- Player is asked to create an ID card with: name, birthdate, appearance, town name.
- Player chats with an NPC in a personality quiz-esque dialogue. Results decide fruit, flower, house color
- Player arrives in town from the train station
- Map is generated from basic rules
  - Cliff line
  - River with lake to the ocean
  - Pond
  - Pine trees in top, pine and normal in second, normal middle, palm trees in beach
  - Grass, dirt, tall grass
  - Stones, bushes, flowers
  - Stairs, bridges
  - Buildings - train station, shop, tailor, home, museum, dump, dock
  - Neighbor houses, neighbors
- Every day at 3am a 'new day' is triggered and updates the map etc.
- Auto-save every minute

- Main page selects an awake NPC to track camera in town.
- Player starts inside their house next to bed on continue.
- Player actions
  - walk
  - interact
  -

Milestone 1

- Player sees main menu with options: Continue, New Game, Options, Credits
- Player starts new game which creates a new map

## Schemas

Map - Tilemaps
Map content

- Weeds
- Flower
- Bush
- Tree
- Rock
- Building

Map tracks all content locations.
Weeds tracks:

- date planted
  Flower tracks:
- date planted
- variety
- color
- genetics
- date last picked
- water gauge
  Flowers track:
- trigger type
- can be dug
- growth behavior
- can be picked on interaction
- can be watered

Tree
position
dateTimePlanted
dateTimeShook
isChopped
health

## Features

### MVP

- Player can move in all four directions fluidly in incremental movements, including diagonals.
- Blocked by obstructions like cliffs, trees.
- Save status automatically.
- Dash with Shift.
- Can pick up items (flower, fruit, coin, star, tools)
- Can use tools (shovel to dig hole, axe to cut tree)
- Shake trees and bushes for fruit.
- Music that changes with time of day.

## Menus and Options

- Main page with New Game, Continue, Settings, How To, Credits
- Sound settings for Music and SFX
- M opens menu with Exit, sound settings, etc.

### World System

- Display: date, day of week, time
- Display: weather, season, temperature
- Change lighting based on time of day
- Change tiles based on season
- Change lighting based on light source
- Randomize weather based on season (cloudy, clear, windy, sunny, stormclouds, rain/snow, heavy rain/snow, thunderclouds, storm)

### Player Creator

- Player can choose their name.
- ...island name.
  [] birthday
- ...hair skin, hair, and eye colors.
- ...hairstyle.
- ...clothing color.
- ...pants or skirt
- ...accessory

## Inventory System

[] Can open and close Inventory menu with I that displays held items.
[] Can navigate between held items and select for options.
[] Select options include: use, hold, bury. Inventory closes with action. Can cancel with Esc/B.
[] Can auto-sort.

## Player Verbs

[] Can interact with objects with A/mouse-click.
[] Shake tree/bush.
[] Talk to NPC.
[] Open sale bin.
[] Can use held tools with A/mouse-click.
[] Shovel to dig up items, create holes.
[] Shovel to fill hole, bury item.
[] Hammer to hit rocks.
[] Blade to cut trees, grass.
[] Water can to water plants.
[] Torch to light the dark.
[] Net to catch bugs.
[] Fish pole to catch fish.
[] Pick up items on touch
[] Fruit
[] Money
[] Gems/Ore
[] Enter entrances to new scenes.

## NPC

[] NPCs can be interacted with to talk to player.
[] Player can give held item to NPC once per day.
[] NPCs have hidden bond values with the player.
[] Higher bond unlocks friendlier dialogue.
[] NPCs give/send gifts in mail at certain milestones.
[] NPCs follow daily schedules (in bed at night, in home in morning, outside in day...)
[] NPCs have randomized pathing as passive activity.
[] NPC favor requests for items.

## Save System

[] Save player name, appearance, island name, start date.
[] Save map status (plants, items, etc).

## Time System

[] Plants and trees grow every day.
[] Shells appear on beach every few hours.
[] Buried treasure appears every day.

## Shop System

[] NPC shop can be opened to buy:

- [] tools
- [] clothes
- [] music
- [] furniture
- [] gifts
- [] food
- [] home upgrades
  [] Items can be sold to NPCs.
  [] Shop is only open certain times and days

## Collection/Achievement System

[] Collection badge pages in menu (or award wall in house) show what player has found.
[] Collections include: fish, critters, shells/treasure, flowers.
[] NPC bonds show bond levels up to 10.
[] NPC details can be seen the more you get to know them.

## Collectibles

Critters:

- butterflies
- dragonflies
- beetles
- lizards
- frogs
- bats, birds
- crickets
- fireflies
- snails
- crab

Fish:

- trout
- bass
- porgy
- salmon
- carp

Plants:

- flowers/herbs
- fruit
- berries
- vegetables/crops
- mushrooms
- nuts/seeds
- wood/bark

Shells:

- abalone
- conch
- moon shell
- spindle
- top
- scallop
- starfish
- etc...

Gems:

- pearl
- crystal
- amber
- ruby
- emerald
- sapphire
- topaz
- amethyst
- flint
- diamond

Gifts:

- wood carvings
- money note
- doll
- ancient relic
- fossil

Food:

- milk
- tea
- lemonade

## Monsters, Healing

- Add Witch Doctor gameplay with monsters that drop gifts when you heal them.

## Home System

[] Player can interact with bed to save and quit.
[] mirror to change appearance
[] music player to player music
[] TV to watch news/weather
[] box to access big storage
[] use inventory items to change wallpaper, flooring, windows
[] drop items in the tilegrid to decorate home

# NPC Dialogues

- Introduction
- Various chat lines with prereqs:
  - time of day
  - season
  - weather
  - holiday/weekend/birthday
  - location
  - bond
- Gift lines
- Favor lines.
- Bond-up lines.

NPC class fields:

- Name
- Appearance
- birthday
- bond
- bond gifts
- home location
- daily schedule
- favorite item/type (+ hated?)

Personality types:

- awkward and stubborn
- cheerful and charismatic (skyward link)
- sassy and flirtatious
- somber and reliable (time link)
- shy and curious (talas)
- straight-forward and laid-back (ali)
- curious scientist (smith)
- strong and boisterous
- cynical and severe
- proud and hot-tempered
- air-headed and vague
- polite and gentlemanly
- cocky lout (windwaker link)
- feral and gruff (wolf link)
- sleezy yet charming conman

## Skye

- Introduction
  Oh, hello.
  You're new around here, aren't you?
  The name's Skye.
  And yours?
  ...
  [PlayerName], eh?
  Well, nice to meet you [PlayerName]!
- Various lines
  - Oh, hello again, um... ... I'm sorry, what was your name again? I'm good with faces, but just terrible with names. So sorry.
    Right, [PlayerName], I remember now... [PlayerName], [PlayerName], [PlayerName]... I'll be sure not to forget this time!
  - Hello [PlayerName]! I remembered your name this time. I promised I would, didn't I?
  - It's so nice outside today. I love to just take it all in, don't you?
  - You're looking well. ... Why yes, I'm doing well too, thank you.
  - It's rather late to be wandering outside isn't it? Stay safe!
  - The rain can feel a bit dreary sometimes, but I also love the sound as it drums against the eaves. Be careful not to catch a cold.
  - Every season has its charms, but I must admit that spring is my favorite. There's something about seeing the world spring back to life after such a cold, long sleep... It gives me such a hopeful feeling for the year ahead.
  - You're quite a friendly one, aren't you? You always have a kind word to share. I'm most comfortable among nature, but still, it can get lonely out here... I appreciate your company, truly. Oh, but please don't feel obliged to check up on me. I know a visitor when I see one. I've lived on my own here long before you came, and I'm sure long after you've gone as well.
  - Aren't you quite cold in this weather? I hate the chill myself! Not enough layers in the world to stay comfortable in this kind of weather. I must confess that winter is my least favorite time of year.
  - Despite the awful cold, I admit the morning after a pure-white snowfall makes for a beautiful vision. It's like out of a fairytale, really.
  - What do I like? Hm, that's such an open question, I feel a bit put on the spot. I guess I like... birds? Is that the kind of answer you're looking for?
  - Do I have any hobbies? Hm, I guess my hobby would be woodcarving. I'm not a pro or anything, but it's fun to make simple figures and trinkets. They don't serve much purpose, really, but I give them as gifts sometimes. ...Perhaps I can make you one sometime.
  - What's my favorite food? I'm not picky, really. Any food is good food in my opinion. I supposed if pressed, I'd say I have a taste for hot pumpkin soup.
  - Ugh... Sorry, today's been a bit of a doozy for me. I don't have the energy to chat. It's not you, I promise... I just need to take a load off.
  - You're quite good with that net, aren't you? You're a regular critter-catching pro! I'm not half-bad myself, if you'd believe it, but I don't hold a candle to you!
  - Oh, you got yourself a net have you? I used to enjoy the occasional bug-catching myself! Here's a tip: don't run up and scare off your prey. Sneak up slowly to catch them off-guard!
  -

# IDEAL NPC Dialogue System

Interacting with an NPC opens a menu wheel of interaction options ala The Sims.
Available options depend on factors like:

- bond level
- NPC activity
- location, time, season, etc.
- previous interactions
  The player can interact a limited number of times before the NPC signals they can't
  continue talking. 'Politely breaking conversation' like 'I'd love to stay and chat, but I've got things to do' or 'I'm sorry, but I've talked too much and my throat hurts.'
  If the player keeps trying to engage, relationship deteriorates and NPC responds increasingly more bothered.
  If NPC reaches their limit, they'll reach 'angered' or 'upset' state and is un-interactible. They hold a long grudge for this: 'I'm still mad at you. Don't talk to me.'
  The better the bond with an NPC, the more you can interact before it's a problem.
  The longer it's been since the last interaction, the more interactions are possible. Ex. after a week absence, you can talk 5 times, but after 10 hours, you can interact 1 time.

Players can get different relationship labels based on interactions, ex. if you 'dance' with someone often, they may become a 'dance partner' and the NPC will dance when you're near or come up and ask you to dance.

Interaction options include:

- Greet
- Joke
- Dance
- Hug
- Sing
- Play game
- Flirt
- insult
- gossip
- Ask
  - birthday, full name, favorite/hated item/color/style/food/weather/etc., phone number, mail address, job, family, friends, lover, doing now, mood, ask THEM a favor, if they have a favor, where from, what do they think of you, what do they think of others, hints and tips, come over, visit, dream, fear, plans for later, etc.
