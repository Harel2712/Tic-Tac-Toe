using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace AppTictac
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tvinfo, tvstart;
        Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnreset, btno, btnx;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            tvinfo = FindViewById<TextView>(Resource.Id.tvinfo);
            tvstart = FindViewById<TextView>(Resource.Id.tvstart);
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btn5 = FindViewById<Button>(Resource.Id.btn5);
            btn6 = FindViewById<Button>(Resource.Id.btn6);
            btn7 = FindViewById<Button>(Resource.Id.btn7);
            btn8=FindViewById<Button>(Resource.Id.btn8);
            btn9=FindViewById<Button>(Resource.Id.btn9);
            btnreset=FindViewById<Button>(Resource.Id.btnreset);
            btnx = FindViewById<Button>(Resource.Id.btnx);
            btno=FindViewById<Button>(Resource.Id.btno);



            btno.Click += Onbuttonclicked1;
            btnx.Click += Onbuttonclicked1;
            btn1.Click += Onbuttonclicked1;
            btn2.Click += Onbuttonclicked1;
            btn3.Click += Onbuttonclicked1;
            btn4.Click += Onbuttonclicked1;
            btn5.Click += Onbuttonclicked1;
            btn6.Click += Onbuttonclicked1;
            btn7.Click += Onbuttonclicked1;
            btn8.Click += Onbuttonclicked1;
            btn9.Click += Onbuttonclicked1;
            btnreset.Click += Onbuttonclicked1;



        }

        public static bool Tie(int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == -1)
                    return false;

            }
            return true;
        }
       
        public static void Winner(int[]Result, TextView Tvninfo)
        {
            if (Result[0] == 0 && Result[1] == 0 && Result[2] == 0 || Result[3] == 0 && Result[4] == 0 && Result[5] == 0 || Result[6] == 0 && Result[7] == 0 && Result[8] == 0 || Result[0] == 0 && Result[3] == 0 && Result[6] == 0 || Result[1] == 0 && Result[4] == 0 && Result[7] == 0 || Result[2] == 0 && Result[5] == 0 && Result[8] == 0 || Result[0] == 0 && Result[4] == 0 && Result[8] == 0 || Result[2] == 0 && Result[4] == 0 && Result[6] == 0)
            {
                Tvninfo.Text = "Player O is the Winner";
                Toast.MakeText(Application.Context, "Player O is the Winner", ToastLength.Long).Show();


                for (int i = 0; i < Result.Length; i++)
                {
                    if (Result[i] == -1)
                    {
                        
                        Result[i] = 2;
                    }
                }
            }
            else if (Result[0] == 1 && Result[1] == 1 && Result[2] == 1 || Result[3] == 1 && Result[4] == 1 && Result[5] == 1 || Result[6] == 1 && Result[7] == 1 && Result[8] == 1 || Result[0] == 1 && Result[3] == 1 && Result[6] == 1 || Result[1] == 1 && Result[4] == 1 && Result[7] == 1 || Result[2] == 1 && Result[5] == 1 && Result[8] == 1 || Result[0] == 1 && Result[4] == 1 && Result[8] == 1 || Result[2] == 1 && Result[4] == 1 && Result[6] == 1)
            {
                Tvninfo.Text = "Player X is the Winner";
                Toast.MakeText(Application.Context, "Player X is the Winner", ToastLength.Long).Show();

                for (int i = 0; i < Result.Length; i++)
                {
                    if (Result[i] == -1)
                    {
                        Result[i] = 2;
                    }
                }

            }
            else if (Tie(Result) == true)
            {
                Tvninfo.Text = "The result is TIE";
                Toast.MakeText(Application.Context, "The result is TIE", ToastLength.Long).Show();

            }

        }
        int[] result = new int[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        int turn = -1;
        public void Onbuttonclicked1(object sender, System.EventArgs e)
        {


            Button btn = (Button)sender;

            if (btno == btn )
            {
                btno.Visibility = Android.Views.ViewStates.Invisible;
                btnx.Visibility = Android.Views.ViewStates.Invisible;
                tvstart.Visibility = Android.Views.ViewStates.Invisible;
                tvinfo.Text = "player O turn";
                turn = 0;
            }
            if (btnx == btn)
            {
                btno.Visibility = Android.Views.ViewStates.Invisible;
                btnx.Visibility = Android.Views.ViewStates.Invisible;
                tvstart.Visibility = Android.Views.ViewStates.Invisible;
                tvinfo.Text = "player X turn";
                turn = 1;
                
            }
            if (btn1 == btn )
            {

                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[0]==-1)
                {
                    btn1.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[0] = 0;
                    Winner(result, tvinfo);

                }
                else if(turn== 1 && result[0] == -1)
                {
                    btn1.Text="X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[0] = 1;
                    Winner(result, tvinfo);

                }
                
            }
            if (btn2 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[1] == -1)
                {
                    btn2.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[1] = 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[1] == -1)
                {
                    btn2.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[1] = 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn3 == btn)
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[2] == -1)
                {
                    btn3.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[2] = 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[2] == -1)
                {
                    btn3.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[2] = 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn4 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[3] == -1)
                {
                    btn4.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[3]= 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[3] == -1)
                {
                    btn4.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[3] = 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn5 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[4] == -1)
                {
                    btn5.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[4] = 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[4] == -1)
                {
                    btn5.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[4]= 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn6 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[5] == -1)
                {
                    btn6.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[5]= 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[5] == -1)
                {
                    btn6.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[5]= 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn7 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[6] == -1)
                {
                    btn7.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[6] = 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[6] == -1)
                {
                    btn7.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[6] = 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn8 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[7] == -1)
                {
                    btn8.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[7]= 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[7] == -1)
                {
                    btn8.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[7] = 1;
                    Winner(result, tvinfo);

                }

            }
            if (btn9 == btn )
            {
                if (turn == -1)
                {
                    Toast.MakeText(Application.Context, "You have to choose who starts first!", ToastLength.Short).Show();

                }
                if (turn == 0 && result[8] == -1)
                {
                    btn9.Text = "O";
                    turn = 1;
                    tvinfo.Text = "player X turn";
                    result[8] = 0;
                    Winner(result, tvinfo);



                }
                else if (turn == 1 && result[8] == -1)
                {
                    btn9.Text = "X";
                    turn = 0;
                    tvinfo.Text = "player O turn";
                    result[8] = 1;
                    Winner(result, tvinfo);
                    

                }

            }
            if(btnreset == btn)
            {
                turn = -1;
                tvinfo.Text = "Welcome! choose who starts:";
                btn1.Text = "";
                btn2.Text = "";
                btn3.Text = "";
                btn4.Text = "";
                btn5.Text = "";
                btn6.Text = "";
                btn7.Text = "";
                btn8.Text = "";
                btn9.Text = "";
                btno.Visibility = Android.Views.ViewStates.Visible;
                btnx.Visibility = Android.Views.ViewStates.Visible;
                tvstart.Visibility = Android.Views.ViewStates.Visible;
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = -1;
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}