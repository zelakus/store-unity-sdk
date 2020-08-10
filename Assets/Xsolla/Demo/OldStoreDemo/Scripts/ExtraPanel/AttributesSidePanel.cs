﻿using System.Collections.Generic;
using UnityEngine;
using Xsolla.Login;

public class AttributesSidePanel : MonoBehaviour
{
	[SerializeField]
	GameObject attributeItemPrefab;

	[SerializeField]
	Transform itemParent;

	private List<GameObject> _items;

	private void Awake()
	{
		_items = new List<GameObject>();
		OldUserAttributes.Instance.AttributesChangedEvent += SetAttributes;
	}
	
	private void SetAttributes(List<OldUserAttributeModel> attributes)
	{
		ClearItems();
		attributes.ForEach(AddAttributeItem);
	}
	
	private void AddAttributeItem(OldUserAttributeModel attribute)
	{
		GameObject newItem = Instantiate(attributeItemPrefab, itemParent);
		_items.Add(newItem);
		var attributeItemUi = newItem.GetComponent<AttributesSidePanelItem>();
		attributeItemUi.Initialize(attribute);
	}

	private void ClearItems()
	{
		_items.ForEach(Destroy);
		_items.Clear();
	}
}