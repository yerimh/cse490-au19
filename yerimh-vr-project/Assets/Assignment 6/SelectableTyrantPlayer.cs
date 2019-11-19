using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTyrantPlayer : Selectable
{
    [SerializeField]
    private Material def, hover, selected;
    [SerializeField]
    private bool isSelected = false;
    public Animator anim;
    public int poseNum;
    public AudioSource sound;

    // This method should set the pose parameter in the animator to poseNum 
    public override GameObject OnSelect()
    {
		Debug.Log("Selected");
        anim.SetInteger("pose", poseNum);
        isSelected = true;
		gameObject.GetComponent<MeshRenderer>().material = selected;
        sound.Play();
        // TODO:
        // Set the animator pose value here:
        // Set the object's mesh renderer to the selected material
        // Play the Tyrant's sound clip
        


        return this.gameObject;
    }

    public override GameObject OnHover()
    {
        // TODO:
        // Copy the code from Selectable Tile OnHover Here

        if (gameObject.GetComponent<MeshRenderer>().material != hover && !isSelected)
        {
            gameObject.GetComponent<MeshRenderer>().material = hover;
        }
        return this.gameObject;
    }

    public override void OnDeselect()
    {
        anim.SetInteger("pose", 0);
        
		gameObject.GetComponent<MeshRenderer>().material = def;
        // TODO:
        // Set the animator's pose value to 0
        // Set the object's mesh renderer to the def material
        Debug.Log("Deselect Tyrant");
        isSelected = false;


    }
}
