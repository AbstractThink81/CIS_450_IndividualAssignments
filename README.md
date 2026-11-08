# Contents
These are all projects I did for the CIS 450 course in college. The course was designed to teach software design patterns
by having students do rapid game prototypes where each game uses a new design pattern for the core game mechanic.

### Command Pattern Game
Unfinished rhythm typing game that combines elements of an online typing test with the rhythm game genre.

Each key that the player needs to press is implemented as a command that can be executed, undone, and redone.
The idea was to use the undo/redo to allow the player to view a replay of their inputs for each song after they play it.


### Composite Pattern Game
[The Kanji Pit](https://imp-giraffe.itch.io/kanji-mixing)
A tetris-like game where kanji (Japanese/Chinese characters) fall from the top of the screen, and the player has to direct
them so that they fall on top of kanji that they can form compounds with. When a character touches another character that it's
compatible with, they combine into a single character. When a character is complex enough that it can no longer be used to form
another compound, it is cleared from the screen to make room for more kanji. This game idea works because one of the core ideas of
kanji is that the majority of all characters are formed by combinations of two or more simpler characters.

The composite design pattern is a design pattern where individual objects and compositions of those individual objects share a common interface.

This game implements the composite design pattern by making every kanji act as a "game piece" that can take up space on the screen, and kanji
objects can be joined into kanji-compound objects that fit the same "game piece" interface, but are made up of a list of simpler kanji.


### Factory Method Pattern Game
[Touhou Clone](https://imp-giraffe.itch.io/touhou-clone)
A bullet-hell game that takes heavy inspiration from the Touhou series.

Each bullet pattern subclasses the `Attack` class, and the `Attack` class has a factory `StartAttack` method that spawns all of the bullets for that
pattern asyncronously. As the battle progresses, the boss enemy uses different bullet patterns.


### OOP Review
Small project to review basic OOP concepts.

There are a few cartoon creatures on the screen, and the user can press different keys on the keyboard to make the creatures do different things.
All creatures subclass `Fuzzle`, which means they can `DoATrick`. There are two interfaces `ICanSleep`, and `ICanLaugh`. Some of the creatures
implement these interfaces to enable them to do the respective actions.


### Object Pooling Game
[Kanji Tiles](https://imp-giraffe.itch.io/kanji-tiles)

A simple memory tile game. This game uses the object pooling design pattern by keeping a large amount of tiles instantiated at all times and
simply arranging them into a certain size grid whenever the player starts a new game.


### Observer Pattern Game
Quiz Game.

The `QuizManager` is an `ISubject`, which can register observers. `AnimationManager` and `UIManager` both implement `IObserver` and react differently
when the `QuizManager` broadcasts that the user has answered a quiz question either correctly or incorrectly.

### State Pattern Game
Unfinished game intended to teach bitwise math operations.

The idea was to make the game switch between an "type the answer" state, and a "results" state, where each state registers keyboard inputs differently.


### Strategy Pattern Game
[Box Blitz](https://imp-giraffe.itch.io/box-blitz)

Boxes come in 5 "varieties": `Red`, `Blue`, `Green`, `Yellow` or `Bomb`. When boxes reach the `Accumulator`, they have different behavior
depending on their variety. Each variety has a different point value: 100 (red), 200 (yellow), 300 (green), 400 (blue), and 2000 (bomb).
The accumulator changes color throughout the game, so the player needs to make sure that all boxes heading toward the `Accumulator` match
the color. If the color matches, the player gains points equal to the point value of the box, but if the color doesn't match, then the
player loses points equal to the point value of the box. The accumulator never switches to bomb color (camo), so the player needs to make
sure to discard all bombs. The game gets progressively faster which makes it harder to move the boxes before they reach the end of the path.
