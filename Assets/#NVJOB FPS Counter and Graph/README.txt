FPS counter has a buffer in which it stores values, then the mean arithmetic value is calculated from these values.

Features:
- The graph is drawn after a given time (graphUpdate variable), and not once per frame.
- Coroutine responsible for drawing the graph is run once in void Awake ().
- Graph lines are stored in a static pool and are subsequently taken from there and returned there.
- You can use FPS counter as a class by calling it from anywhere else.

Full instructions - https://nvjob.github.io/unity/nvjob-fps-counter-and-graph

Distributed with MIT License.