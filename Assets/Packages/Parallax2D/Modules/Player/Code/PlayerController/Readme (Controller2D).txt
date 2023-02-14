Script for character management. On the player add such components, rigidbody2d and Collider2D and add the script. The script has three fields:
	- Layer Mask - Layer from which the object can jump
	- Move speed - Character movement speed
	- Jump force - Jump power of the character

	In the player object, you need to create a child object GroundCheck. To lower it it is necessary hardly more low than collider. The script checks if it touches the platform with the layer we need, if so, then we can jump.