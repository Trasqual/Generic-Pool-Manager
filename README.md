# Generic-Pool-Manager
 
This project features a generic pool manager for gameobjects that is using Unity's object pooling system.

To use it all you need to do is the call the ObjectPoolManager's GetObject<T>() method. This will check if there is a pool for the type of T and if there isn't it will create one. If there is a pool of type T then it will just Get() an object from the pool.

After using the object you got from the pool, you can use ObjectPoolManager's ReleaseObject(objectToRelease) method with will find the pool of the same type and Release() the object.

I created an example where if you click with left mouse button, you get a cube item and if you click with the right mouse button you get a sphere item. To release you can click 1 and 2 on your keyboard accordingly.
