using UnityEngine;


namespace ReadyGamerOne.Script
{
	[RequireComponent(typeof(CircleCollider2D))]
	public abstract class CloseEnough : MonoBehaviour
	{
		
		public LayerMask testLayer;
		protected bool isClose { private set; get; }
		protected virtual  void  Start()
		{
			this.isClose = false;
			this.gameObject.layer = LayerMask.NameToLayer("Trigger");
			this.GetComponent<CircleCollider2D>().isTrigger = true;
		}

		protected virtual void OnEnterRightLayerObj(Collider2D col)
		{
			
		}

		protected virtual void OnExitRightLayerObj(Collider2D col)
		{
			
		}

		protected  void  OnTriggerEnter2D(Collider2D col)
		{
			//Debug.Log("第" + col.gameObject.layer + "位");
			if (((this.testLayer.value>>(col.gameObject.layer))&1)!=0)
			{
				this.isClose = true;
				OnEnterRightLayerObj(col);
			}
		}

		protected  void OnTriggerExit2D(Collider2D col)
		{
			//Debug.Log(this.testLayer.value);
			if (((this.testLayer.value >> (col.gameObject.layer)) & 1) != 0)
			{
				this.isClose = false;
				OnExitRightLayerObj(col);
			}
		}
	}	

}

