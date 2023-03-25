# Lawnmower Simulator
## COMP 225-01: Software Design and Development

Unity prototype of Lawnmower Simulator. Features:
- Lawnmower movement and rotation based on direction
- Collisions with game objects such as the world barrier
- Four different ways to mow the lawn:
  - TileMap-based mowing
  - Sprite mask mowing
  - Pixel-by-pixel mowing
  - Particle-based mowing
  
Strengths of the TileMap approach:
- Low performance overhead--the game only ever deletes tiles and the code runs (in theory) in O(1) time. No additional GameObjects are created.
- Its implementation is simple and easy to understand and modify.
Limitations of the TileMap approach:
- To make the mowing appear natural, the TileMap would have to be significantly scaled down. This messes up the bound/position checking code that happens in the script. 
- Even with a tiny TileMap, jagged edges can still appear. 
- Bounds and collision checking is weird. Sometimes, especially with larger tiles, tiles the mower isn't even going over will get removed.
