/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

using System.Collections.Generic;

using Tizen.NUI.Constants;

class HelloWorldExample : NUIApplication
{
    Animation animation;
    View container;
    TextLabel child;

    TapGestureDetector detector;
    

    protected override void OnCreate()
    {
        // Up call to the Base class first
        base.OnCreate();
        detector = new TapGestureDetector();

        Window window = Window.Instance;
        window.BackgroundColor = Color.White;

        ScrollableBase root = new ScrollableBase()
        {
            Size = new Size(Window.Instance.WindowSize),
            Name = "Root",
            ScrollDuration = 2000,
            FlickDistanceMultiplierRange = new Vector2(3.0f,4.0f),
        };
        window.GetDefaultLayer().Add(root);

        container = new View()
        {
            Size = new Size(480,20000),
            BackgroundColor = Color.Yellow,
            Layout = new AbsoluteLayout(),
            Name = "Container",
        };
        root.Add(container);

        for(int i = 0 ; i<2000;i++)
        {
            View item = new View()
            {
                Size = new Size(480,100),
                BackgroundColor = i%2 == 0 ? Color.Magenta:Color.Cyan,
                Position = new Position(0,i*100),
            };
            container.Add(item);
        }

        child = new TextLabel()
        {
            Size = new Size(480,150),
            BackgroundColor = Color.Blue,
            Name = "Child",
            Text ="YOU!!!!!!",
        };
        container.Add(child);


        View animationButton = new View()
        {
            Size = new Size(100,100),
            Position = new Position(180,540),
            BackgroundColor = Color.Green,
        };
        window.GetDefaultLayer().Add(animationButton);

        animationButton.TouchEvent += (object source,View.TouchEventArgs args)=>
        {
            if(args.Touch.GetState(0)==PointStateType.Up)
            {
                if(animation == null)
                {
                    animation = new Animation(5000);
                    animation.AnimateTo(container,"PositionY",-1000);
                    animation.EndAction = Animation.EndActions.Cancel;
                    animation.DefaultAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine);
                }
                animation.Stop();
                animation.Play();
            }

            return true;
        };


        View moveChildButton = new View()
        {
            Size = new Size(100,100),
            Position = new Position(280,540),
            BackgroundColor = Color.Black,
        };
        window.GetDefaultLayer().Add(moveChildButton);
        detector.Attach(moveChildButton);

        moveChildButton.TouchEvent += (object source,View.TouchEventArgs args)=>
        {
            if(args.Touch.GetState(0)==PointStateType.Up)
            {
                child.Text = "CHANGE!!!!!!!!!!!!";
            }

            return true;
        };
        
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread] // Forces app to use one thread to access NUI
    static void Main(string[] args)
    {
        HelloWorldExample example = new HelloWorldExample();
        example.Run(args);
    }
}

