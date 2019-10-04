# #NVJOB FPS Counter and Graph - simple and fast (for Unity)

Version 1.2

FPS counter with graph.<br>
The FPS counter has a buffer in which it stores values, then the mean arithmetic value is calculated from these values.

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

------------------------------------

https://www.youtube.com/watch?v=suy4ND4_hn4

https://www.youtube.com/watch?v=fnTN8IWTiNs

![GitHub Logo](https://github.com/nvjob/Unity-FPS-Counter/blob/master/Images/Unity-FPS-Counter-1.png?raw=true)

![GitHub Logo](https://github.com/nvjob/Unity-FPS-Counter/blob/master/Images/Unity-FPS-Counter-0.png?raw=true)

------------------------------------

### Authors
Designed by #NVJOB Nicholas Veselov | https://nvjob.pro | http://nvjob.dx.am | https://twitter.com/nvjob

### License
This project is licensed under the MIT License - see the LICENSE file for details

### Donate
You can thank me by a voluntary donation. https://nvjob.pro/donations.html
