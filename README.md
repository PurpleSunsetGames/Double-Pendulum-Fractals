# DoublePendulumFractals
  A Double Pendulum fractal and simulation in both Desmos and Unity compute shaders.
  Double Pendulums are chaotic systems which produce interesting behavior, and by extention very interesting visualizations. One of these visualizations is known as the double pendulum fractal; a colorful, increasingly detailed equation that becomes more complex and intricate the more time passes. These programs explore the double pendulum fractal in a fun and (hopefully) intuitive way.
  The desmos graph is fully functional at the moment, but I do plan to add more features later on. It is also much slower than the compute shader, of course, despite the 4x speedup that I've managed to obtain using desmos's new substitution feature. To use this graph simply:
- Move the draggable point around on the rainbow square to select the starting condition of the displayed pendulum. (the color of the square at the position of the point represents the pendulums current condition)
- Adjust resolution with the slider to suit your machine (keep in mind that the farther in time you go, the laggier it will be)
- Increment time and see how it evolves! Currently it can only go up to 113 iterations because of the way desmos works.
- Move the draggable point around again to see how drastically different all the pendulums end up as because of their starting position!

  To use the Unity program, simply download and unzip the zipped file (the latest one in releases) and double-click the one inside the folder named "gpustuffs."
