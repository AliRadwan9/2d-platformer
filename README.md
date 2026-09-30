2D Pixel Action Platformer

A responsive 2D action platformer built in Unity and C#. The project showcases a physics-based character controller, melee combat hitboxes, dynamic enemy pathing, and a directional dash mechanic, all wrapped in a custom pixel art visual style.

Features

The player features responsive physics-driven horizontal movement, ground checks, variable jump heights, and wall detection. A directional dash provides a quick burst of speed with temporary invulnerability windows and cooldown management. Melee sword combat uses precise 2D collision detection synced to animation frames to register hits on enemies cleanly. The enemy AI tracks player proximity, dynamically flipping its orientation and pursuing the player across the level. Integrated Unity Animator controllers handle sprite state transitions for idle, running, jumping, falling, dashing, and attacking.

Controls

Movement uses A and D or the arrow keys on keyboard, or the left analog stick and directional pad on a controller. Jump is bound to Space or the south gamepad button. Dash activates with Left Shift or the west gamepad button. The sword attack triggers with Left Mouse Button, J, or the right trigger and east gamepad button.

Technical Architecture

Scripts are modular and separated by domain. The player systems are divided into dedicated controllers for horizontal physics, jumping, dash logic, combat execution, and animation triggers. The enemy utilizes decoupled pursuit scripts alongside health and knockback management. Sword swings use timed overlap circle checks rather than loose dynamic colliders, preventing frame tunneling and ensuring hits only register during active swing frames. The dash momentarily neutralizes gravity to keep player trajectory predictable across ground and air movement.

What i learned

Physics interactions in 2d unity, the use of state machines, code modularity and basic enemy behaviours.
