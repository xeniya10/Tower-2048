using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTicker : MonoBehaviour
{
    float tickerAngle = 50f;
    float towerAngle = 0f;
    float towerSpeed = 0f;

    // 	public void Update()
    // {
    // 	Quaternion tickerStartAngle = Quaternion.AngleAxis(tickerAngle, Vector3.forward);
    // 	Quaternion tickerEndAngle = Quaternion.AngleAxis(-tickerAngle, Vector3.forward);
    // 	Quaternion towerStartAngle = Quaternion.AngleAxis(towerAngle, Vector3.forward);
    // 	Quaternion towerEndAngle = Quaternion.AngleAxis(-towerAngle, Vector3.forward);
    // 	float time = Time.time;
    // 	BlockTicker.rotation = Quaternion.Lerp(tickerStartAngle, tickerEndAngle, (Mathf.Sin(time * 1.5f)) / 2 + 0.5f);
    // 	BlockTower.rotation = Quaternion.Lerp(towerStartAngle, towerEndAngle, (Mathf.Sin(time * towerSpeed)) / 2 + 0.5f);
    // 	AddBlock();

    // 	if (Input.GetKeyDown(downKey))
    // 	{
    // 		PutSound.Play();

    // 		foreach (int item in blockNumbers)
    // 		{
    // 			SumScore = Math.Max(SumScore, item);
    // 		}
    // 		ScorePanel.SetText($"{SumScore}");

    // 		Transform playBlock = blocks[blocks.Count - 1];
    // 		playBlock.rotation = Quaternion.Euler(0, 0, 0);
    // 		blockRigidbody.useGravity = true;
    // 		blockRigidbody.isKinematic = false;
    // 		blockRigidbody.velocity = -playBlock.up * 40f;
    // 		playBlock.SetParent(BlockTower);
    // 		StartCoroutine(DoAfterPause());
    // 		if (blocks.Count > 4 && Vector3.Distance(blocks[blocks.Count - 1].position, blocks[blocks.Count - 2].position) < 18f)
    // 		{
    // 			StartCoroutine(DoCycleAfterPauseDown());
    // 			towerAngle += 0.06f;
    // 			towerSpeed += 0.03f;
    // 		}
    // 		if (blocks.Count > 10 && Vector3.Distance(blocks[blocks.Count - 1].position, blocks[blocks.Count - 2].position) > 35f)
    // 		{
    // 			StartCoroutine(DoCycleAfterPauseUp());
    // 		}
    // 	}
    // }

    // private IEnumerator DoAfterPause()
    // {
    // 	yield return new WaitForSeconds(1.5f);
    // 	BlockTicker.rotation = Quaternion.Euler(0, 0, 0);
    // 	CreateNewBlock();
    // }

    // private IEnumerator DoCycleAfterPauseDown()
    // {
    // 	for (float step = 0; step < 0.45f; step += 0.01f)
    // 	{
    // 		Floor.position += Vector3.down * step;
    // 		BlockTower.position += Vector3.down * step;
    // 		yield return new WaitForSeconds(0.01f);
    // 	}
    // }

    // private IEnumerator DoCycleAfterPauseUp()
    // {
    // 	for (float step = 0; step < 0.2f; step += 0.01f)
    // 	{
    // 		Floor.position += Vector3.up * step;
    // 		BlockTower.position += Vector3.up * step;
    // 		yield return new WaitForSeconds(0.01f);
    // 	}
    // }
}
