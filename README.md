# #NVJOB FPS Counter and Graph - simple and fast (for Unity)

Version 1.2

FPS counter with graph.<br>
The FPS counter has a buffer in which it stores values, then the mean arithmetic value is calculated from these values.

https://www.youtube.com/watch?v=suy4ND4_hn4 <br/>
https://www.youtube.com/watch?v=fnTN8IWTiNs

- The graph is drawn after a given time (graphUpdate variable), and not once per frame.<br>
- Coroutine responsible for drawing the graph is run once in void Awake ().<br>
- Graph lines are stored in a static pool and are subsequently taken from there and returned there.<br>
- You can use FPS counter as a class by calling it from anywhere else:
```
public class Example : MonoBehaviour
{
using UnityEngine;
    void Update()
    {
       print(StFPS.Counter(60, Time.deltaTime));       
    }
}
```

### Prerequisites

To work on the project, you will need a Unity version of at least 2019.1.8 (64-bit).

![GitHub Logo](https://github.com/nvjob/Unity-FPS-Counter/blob/master/Images/Unity-FPS-Counter-1.png?raw=true)
![GitHub Logo](https://github.com/nvjob/Unity-FPS-Counter/blob/master/Images/Unity-FPS-Counter-0.png?raw=true)

-------------------------------------------------------------------

### Authors
Designed by #NVJOB Nicholas Veselov - https://nvjob.github.io

### License
MIT License - https://github.com/nvjob/Unity-FPS-Counter/blob/master/LICENSE

### Donate
Help for this project - https://nvjob.github.io/donate
