using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//UI 스크립트를 따로 만들어서 GameObject.Find("UI_Setting").GetComponent<UI_Setting_S>().Buy_UI();로 꺼내쓸 수 있게 

public class UI_Setting_S : MonoBehaviour
{
	float state_time;

	private Image Buy_Image;
	[SerializeField]
	private Sprite[] Buy_images;

	int stop_land_number;
	Sprite ui_image;
	GameObject UI_Ob;
	bool state;

	void Start()
	{
		UI_Ob = GameObject.Find("UI");
		state_time = 0f;
	}

	void Update()
	{
		if (state) { 
			State();
		}
	}

	//땅에 도착했을 때 UI 등장까지 잠시 state
	void State()
    {
		state_time += Time.deltaTime;
    }

	//구매 UI
	public void Buy_UI()
	{
		state = true;
		if (state_time > 2f)
		{
			Debug.Log("In_Buy");
			stop_land_number = GameObject.Find("Player_1").GetComponent<Player_S>().stop_land_number;
			Debug.Log("사진 인덱스"+stop_land_number);
			Buy_Image.sprite = Buy_images[stop_land_number];
			UI_Ob.transform.GetChild(0).gameObject.SetActive(true);
		}

	}

	//구매UI X버튼 눌렀을 때
	public void Button_X()
    {
		state = false;
		state_time = 0f;
		//집 버튼 눌렀을 때 체크 버튼 false로, 인수할 때도 마찬가지로
		GameObject.Find("house_1").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.Find("house_2").transform.GetChild(0).gameObject.SetActive(false);
		GameObject.Find("house_3").transform.GetChild(0).gameObject.SetActive(false);

		//Buy_Image false
		UI_Ob.transform.GetChild(0).gameObject.SetActive(false);
		GameObject.Find("Player_1").GetComponent<Player_S>().UI_Buy_bool = false;

	}

	//구매 UI에서 집 클리깃 체크표시
	public void Button_house()
    {

		if (EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.activeSelf == false)
		{
			
			EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.SetActive(true);
		}
		else if(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.activeSelf == true)
		{
			EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.SetActive(false);
		}

	}
}
