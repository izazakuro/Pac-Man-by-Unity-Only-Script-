# Pac-Man-by-Unity

I used unity to created a Pac-Man game by following the link beneath.

https://www.youtube.com/watch?v=dCaimhoT4l4&list=PLHrN7HL-00e8HECYZFE-9i9Qf_SRqWxZh

Furthermore, the logic of Ghost AI refered from the the link beneath.

https://gameinternals.com/understanding-pac-man-ghost-behavior

I will just upload my C# scripts because I am facing some error in the unity engine, and I will write the error specifically below.

All of the Sprites are come from creator of these videos. You could get the Sprites from the first link I pasted. 

I finished all of the part he done, and the final test is also worked well. 
However, when I restart the project , I got some errors such like these.

/*
NullReferenceException: Object reference not set to an instance of an object
EnemyController.Setup () (at Assets/EnemyController.cs:125)
GameManager+<Setup>d__51.MoveNext () (at Assets/GameManager.cs:170)
UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) (at <f712b1dc50b4468388b9c5f95d0d0eaf>:0)
UnityEngine.MonoBehaviour:StartCoroutine(IEnumerator)
GameManager:Awake() (at Assets/GameManager.cs:107)
*/

I checked all of components which should be initialized, but it is not effective.
I think I could not solve this problem in short time. Maybe, I will fix it in the future.
If you have some ideas, please comment by the thread. Thanks a lot!

//////////
//Upload//
//////////

The bug caused by coroutine has been fixed!
