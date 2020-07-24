using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogZone : MonoBehaviour {
	[Header("References")]
	[SerializeField] private Text dialogueText;
	[SerializeField] private Text nameText;
	[SerializeField] private TMP_Text questText;
	[SerializeField] private GameObject root;
[SerializeField] private GameObject Hint;
	[Header("Settings")] [SerializeField] private float letterDelay = 0.1f;
	[SerializeField] private bool repeatDialog;
	[SerializeField] private float delayAfterSentence = 1f;

	[Header("Content")] [SerializeField] private string[] sentence;
	[Header("Content")] [SerializeField] private string[] sucessSentence;
	[SerializeField] private string[] characterName;

	[SerializeField] private KeyCode InputKey;

	[SerializeField] private List<GameObject> DisableOnShow = new List<GameObject>();


	private string fullText;
	private string currentText;

	private bool fullSentenceDisplayed = true;
	private int index;
	private float timer;

	private bool inRange;
	private bool canDisplay = false;


	private void Awake()
	{
		if ((nameText == null))
		{
			Debug.LogError("Name text reference not set in Dialog Zone on " + gameObject);
		} else
		{
			nameText.text = characterName[index];
		}

		if (dialogueText == null)
		{
			Debug.LogError("Dialog text reference not set in Dialog Zone on " + gameObject);
		} else
		{
			fullText = sentence[index];
		}

		//You can add inital delay here
		timer = 0f;

		HideDialogue();
	}

	private void reset(){
		canDisplay = false;
		index = 0;
		dialogueText.text = "";
		fullSentenceDisplayed = true;
	}

	private void Update()
	{
		//InputHandling
		if (inRange && SimpleInput.GetButtonDown("Talk"))
		{
			if (gameObject.GetComponent<Quest>().gotItem){
				sentence = sucessSentence;
				questText.fontStyle = FontStyles.Strikethrough | FontStyles.Bold;
			}
			if (!root.gameObject.activeInHierarchy)
			{
				ShowDialogue();
				canDisplay = true;
			} else
			{
				HideDialogue();
				reset();
			}
			
		}

		if (!canDisplay){return;}

		//Dialog Display Handling
		if (index < sentence.Length)
		{
			if (fullSentenceDisplayed)
			{
				if (timer <= 0f)
				{
					fullSentenceDisplayed = false;
					fullText = sentence[index];
					StartCoroutine(ShowText());
				} else
				{
					timer -= Time.deltaTime;
				}
			}
		} else 
		{
			if (fullSentenceDisplayed)
			{
				if (timer <= 0f)
				reset();
			}

		}
	}

	private IEnumerator ShowText()
	{
		for (int i = 0; i <= fullText.Length; i++)
		{
			if(!canDisplay){break;}
			currentText = fullText.Substring(0, i);
			TryApplyText();
			yield return new WaitForSeconds(letterDelay);
		}
		if(canDisplay){
			index++;
		}
		timer = delayAfterSentence;
		fullSentenceDisplayed = true;
	}

	private void TryApplyText()
	{
		if (dialogueText.gameObject.activeInHierarchy)
		{
			dialogueText.text = currentText;

			if ((index < characterName.Length) && (nameText != null))
			{
				nameText.text = characterName[index];
			}
		}
	}


	//Made this in seperate functions so you can modify it for your needs

	private void HideDialogue()
	{
		if (root != null)
		{
			root.SetActive(false);
				
		}
	}

	private void ShowDialogue()
	{
		if (root != null)
		{
			root.SetActive(true);
	
		}

		DisableOnShow.ForEach(d => d.SetActive(false));
	}

  private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			inRange = true;
			Hint.SetActive(true);
		}
	}

	
   private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			inRange = false;
			Hint.SetActive(false);
			reset();
		}

			HideDialogue();
		
		}
	}
