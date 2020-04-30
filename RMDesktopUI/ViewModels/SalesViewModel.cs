using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
		#region Private Fields
		private BindingList<string> _products;
		private string _itemQuantity;
		private BindingList<string> _cart; 
		#endregion

		#region Public properties
		public BindingList<string> Products
		{
			get { return _products; }
			set
			{
				_products = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		public BindingList<string> Cart
		{
			get { return _cart; }
			set
			{
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

		public string ItemQuantity
		{
			get { return _itemQuantity; }
			set
			{
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}
		#endregion

		#region Computed Values
		public string SubTotal
		{
			get
			{
				//TODO - Replace with calculated value
				return "$ 0.00";
			}
		}

		public string Tax
		{
			get
			{
				//TODO - Replace with calculated value
				return "$ 0.00";
			}
		}

		public string Total
		{
			get
			{
				//TODO - Replace with calculated value
				return "$ 0.00";
			}
		}
		#endregion

		#region Observables
		public bool canAddToCart
		{
			get
			{
				bool output = false;
				//TODO -  make sure something is selected
				//TODO - make sure there is an item quantity
				return output;
			}
		}

		public bool canRemoveFromCart
		{
			get
			{
				bool output = false;

				return output;
			}
		}

		public bool canCheckOut
		{
			get
			{
				bool output = false;
				//TODO - Make sure there's something in the cart
				return output;
			}
		}
		#endregion

		#region Methods
		public void AddToCart()
		{

		}

		public void RemoveFromCart()
		{

		}
				
		public void Checkout()
		{

		} 
		#endregion

	}
}
