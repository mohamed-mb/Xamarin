package md569a699c14bd800169e67ae34ab3e9592;


public class CircleImageRendererAndroid
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.ImageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_drawChild:(Landroid/graphics/Canvas;Landroid/view/View;J)Z:GetDrawChild_Landroid_graphics_Canvas_Landroid_view_View_JHandler\n" +
			"";
		mono.android.Runtime.register ("WhackAMonkey.Droid.CircleImageRendererAndroid, WhackAMonkey.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CircleImageRendererAndroid.class, __md_methods);
	}


	public CircleImageRendererAndroid (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == CircleImageRendererAndroid.class)
			mono.android.TypeManager.Activate ("WhackAMonkey.Droid.CircleImageRendererAndroid, WhackAMonkey.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CircleImageRendererAndroid (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == CircleImageRendererAndroid.class)
			mono.android.TypeManager.Activate ("WhackAMonkey.Droid.CircleImageRendererAndroid, WhackAMonkey.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public CircleImageRendererAndroid (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CircleImageRendererAndroid.class)
			mono.android.TypeManager.Activate ("WhackAMonkey.Droid.CircleImageRendererAndroid, WhackAMonkey.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public boolean drawChild (android.graphics.Canvas p0, android.view.View p1, long p2)
	{
		return n_drawChild (p0, p1, p2);
	}

	private native boolean n_drawChild (android.graphics.Canvas p0, android.view.View p1, long p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}