# #NVJOB FPS Counter and Graph - simple and fast 1.2
#### [nvjob.github.io/unity/nvjob-fps-counter-and-graph](https://nvjob.github.io/unity/nvjob-fps-counter-and-graph)

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/fps%20counter%20and%20graph/12/pic/Unity-FPS-Counter-1.jpg)

FPS counter with graph for Unity.<br>
The FPS counter has a buffer in which it stores values, then the mean arithmetic value is calculated from these values.

-------------------------------------------------------------------

### Prerequisites
To work on the project, you will need a Unity version of at least 2019.1.8 (64-bit).

### Information
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

#### Video manual:
[youtube.com/watch?v=suy4ND4_hn4](https://www.youtube.com/watch?v=suy4ND4_hn4)<br>
[youtube.com/watch?v=fnTN8IWTiNs](https://www.youtube.com/watch?v=fnTN8IWTiNs)

-------------------------------------------------------------------

![GitHub Logo](https://raw.githubusercontent.com/nvjob/nvjob.github.io/master/repo/unity%20assets/fps%20counter%20and%20graph/12/pic/Unity-FPS-Counter-0.jpg)

-------------------------------------------------------------------

**Authors:** #NVJOB Nicholas Veselov - [nvjob.github.io](https://nvjob.github.io)

**License:** MIT License. Clarification of licenses - [nvjob.github.io/mit-license](https://nvjob.github.io/mit-license)

**Support:** [nvjob.github.io/support](https://nvjob.github.io/support)
