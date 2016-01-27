﻿// ***********************************************************************
// Copyright (c) 2016 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using NUnit.Framework;
using NSubstitute;

namespace NUnit.Gui.Presenters.TestTree
{
    using Model;
    using Model.Settings;
    using Views;

    public class TestTreePresenterTestBase
    {
        protected ITestTreeView _view;
        protected ITestModel _model;

        [SetUp]
        public void CreatePresenter()
        {
            _view = Substitute.For<ITestTreeView>();
            _model = Substitute.For<ITestModel>();
            _model.Settings.Returns<SettingsModel>(new SettingsModel( new UserSettingsFake() ));

            new TreeViewPresenter(_view, _model);

            // Make it look like the view loaded
            _view.Load += Raise.Event<System.EventHandler>(null, new System.EventArgs());
        }
    }
}
