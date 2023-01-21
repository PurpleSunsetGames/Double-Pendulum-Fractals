# DoubePendulumFractals
  A Double Pendulum fractal and simulation in both Desmos and Unity compute shaders.
  Double Pendulums are chaotic systems which produce interesting behavior, and by extention very interesting visualizations. One of these visualizations is known as the double pendulum fractal; a colorful, increasingly detailed equation that becomes more complex and intricate the more time passes. These programs explore the double pendulum fractal in a fun and (hopefully) intuitive way.
  The desmos graph is fully functional at the moment, but I do plan to add more features later on. It is also much slower than the compute shader, of course, despite the 4x speedup that I've managed to obtain using desmos's new substitution feature. To use this graph simply:
- Move the draggable point around on the rainbow square to select the starting condition of the displayed pendulum. (the color of the square at the position of the point represents the pendulums current condition)
- Adjust resolution with the slider to suit your machine (keep in mind that the farther in time you go, the laggier it will be)
- Increment time and see how it evolves! Currently it can only go up to 113 iterations because of the way desmos works.
- Move the draggable point around again to see how drastically different all the pendulums end up as because of their starting position!

  The compute shader and C# script currently do not run on their own, so if you want to use or edit them you'll have to import them into unity. To do this:
- Attach the C# script to an "Image" UI object (which would prefereably be attached to a Canvas aswell)
- Drag the compute shader (NCShader) into the compute shader public variable within Unity
- Set the other public variables (except for Sprite, RenderTexture, Texture2D and Image) to whatever you like. Recommended resolution is 256x256. Timestep should be around .06 and Friction should be very close to 1.
- Currently Time (iterations) are determined by the mouse's x position, so.... yeah
- WIGGLE THE MOUSE
- Look at the pretty colors
