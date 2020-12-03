﻿using System;
using Xsolla.Demo;

namespace Xsolla.Core.Popup
{
	public interface ITutorialPopup
	{
		ITutorialPopup SetTutorialInfo(TutorialInfo info, bool showWelcomeMessage);
		ITutorialPopup SetCancelCallback(Action onCancel);
		ITutorialPopup SetCompletionCallback(Action onComplete);
	}
}