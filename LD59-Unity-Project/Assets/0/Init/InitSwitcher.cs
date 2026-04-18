using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class InitSwitcher : MonoBehaviour
{
	public Image black;
	public Image lbbLogo;
	public TextMeshProUGUI madeBy;
	public TextMeshProUGUI forLD;
	public Image gameLogo;

	private IEnumerator Start()
	{
		black.gameObject.SetActive(true);
		lbbLogo.gameObject.SetActive(false);
		madeBy.gameObject.SetActive(false);
		forLD.gameObject.SetActive(false);
		gameLogo.gameObject.SetActive(false);
		black.DOFade(1, 0f);
		yield return new WaitForSeconds(0.5f);
		
		lbbLogo.gameObject.SetActive(true);
		black.DOFade(0, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f);
		black.DOFade(1, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.1f);
		lbbLogo.gameObject.SetActive(false);
		madeBy.gameObject.SetActive(true);
		black.DOFade(0, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f);
		black.DOFade(1, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.1f);
		madeBy.gameObject.SetActive(false);
		forLD.gameObject.SetActive(true);
		black.DOFade(0, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f);
		black.DOFade(1, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.1f);
		forLD.gameObject.SetActive(false);
		gameLogo.gameObject.SetActive(true);
		black.DOFade(0, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(1f);
		black.DOFade(1, 0.5f);
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForSeconds(0.1f);
		gameLogo.gameObject.SetActive(false);
		
		SceneManager.LoadScene("0/Scenes/MainScene");
	}
}
