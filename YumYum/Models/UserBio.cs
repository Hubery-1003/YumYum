using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class UserBio
{
    public int UserId { get; set; }

    public string? UserIntro { get; set; }

    public string? HeadShot { get; set; }

    public string? Igaccount { get; set; }

    public string? Fbnickname { get; set; }

    public string? YoutuNickname { get; set; }

    public string? WebNickName { get; set; }

    public string? YoutuLink { get; set; }

    public string? Fblink { get; set; }

    public string? WebLink { get; set; }

    public virtual UserSecretInfo User { get; set; } = null!;
}
