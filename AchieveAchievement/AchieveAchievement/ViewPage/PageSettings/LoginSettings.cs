namespace AchieveAchievement.ViewPage.PageSettings
{
    public class LoginSettings
    {
        #region PageLeftSide
        public static void ShowHidePassword(ref Entry passwordEntry, ref Image passwordEye)
        {
            passwordEntry.IsPassword = !passwordEntry.IsPassword;

            if (passwordEntry.IsPassword)
                passwordEye.Source = "closed_eye_w.png";
            else
                passwordEye.Source = "open_eye_w.png";
        }


        public static void SignInBtnSelectionClicked(ref BoxView lineSignBtnSelected,
                                                     ref Button signBtnConfirmed,
                                                     ref Grid accountCreateGrid)
                                                     //ref Frame socialMediaFrame,
                                                     //ref Label rightBodyLabelText)
        {
            lineSignBtnSelected.SetValue(Grid.ColumnProperty, 0);
            signBtnConfirmed.Text = "LOG IN";
            signBtnConfirmed.BackgroundColor = Color.FromRgb(0, 128, 0);

            accountCreateGrid.IsVisible = false;

            //Do not erase, uncomment only when login with Google and Facebook are implemented
            //socialMediaFrame.IsVisible = true;
            //rightBodyLabelText.IsVisible = true;
        }

        public static void SignUpBtnSelectionClicked(ref BoxView lineSignBtnSelected,
                                                     ref Button signBtnConfirmed,
                                                     ref Grid accountCreateGrid,
                                                     ref Frame socialMediaFrame)

        {
            lineSignBtnSelected.SetValue(Grid.ColumnProperty, 1);
            signBtnConfirmed.Text = "CREATE";
            signBtnConfirmed.BackgroundColor = Color.FromRgb(85, 0, 255);

            socialMediaFrame.IsVisible = false;
            accountCreateGrid.IsVisible = true;
        }


        #endregion

    }
}
