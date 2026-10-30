# 3d-unity-feedback

Cheap visual feedback for fights on the IT Kamianets 3D Engine, made from Unity primitives so it needs no art.

### Logic

- `Fx.Pulse` makes a primitive that grows from one size to another and disappears: a flat cylinder growing is a ring on the floor (a shockwave, or a red warning that fills up before a heavy blow), a cube growing along one axis is a slash, a small sphere is a hit spark. `Fx.Material` gives a plain lit material of one colour, made once and reused.
- `HealthBar3D` goes next to a `Health` (from `3d-unity-combat`) and draws a small bar above the character that faces the camera and shrinks as health drops. It hides when the character dies.

What the effects mean and when they play is the game's business. When a game has real art, it replaces these with its own and the gameplay does not change.

### Status

v0.1: `Fx`, `FxPulse`, `HealthBar3D`. Used by Temnorid Dungeons, Conquest and Arena.

### Roadmap

- Floating damage numbers.
- A hit flash on the damaged character.
