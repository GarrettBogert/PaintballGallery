#pragma strict

var smallSplat : GameObject;

function Start () {
 
 
  yield WaitForSeconds(.1);
   var ySplat : float = Random.Range(-.3,.3);
  var wSplat : float = Random.Range(-.3,.3);
  Instantiate(smallSplat,Vector3(transform.position.x, transform.position.y,transform.position.z), transform.rotation);
  Instantiate(smallSplat,Vector3(transform.position.x + ySplat, transform.position.y,transform.position.z + wSplat), transform.rotation);
}

