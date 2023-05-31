import { Product } from "./components/ProductTable";

export async function GetAllProducts(){
    try{
        const response = await fetch("https://localhost:5001/api/products");
        if(!response.ok) throw new Error("Fetching data failed!, Error details: " + response.statusText);
        return await response.json();
    }
    catch(err){
        console.log(err);
    }
}

export async function GetSale(budget: number){
    try{
        debugger;
        const response = await fetch(`https://localhost:5001/api/product/sale?budget=${encodeURIComponent(budget)}`);
        if(!response.ok) throw new Error("Fetching data failed!, Error details: " + response.statusText);
        let text: string = await response.text();
        return text;
    }
    catch(err){
        console.log(err);
    }
}

export async function PostProduct(productPrice: number, productCategory: number){
    let productCategoryString = "PRODUNO";
    if(productCategory === 2){
        productCategoryString = "PRODDOS";
    }

    let product: Product = {
        price: productPrice,
        category: productCategoryString
    }

    try{
        debugger;
        const response = await fetch("https://localhost:5001/api/product", { 
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            method: "POST", body: JSON.stringify(product)
        });
        if(!response.ok) throw new Error("Fetching data failed!, Error details: " + response.statusText);
        return await response.json();
    }
    catch(err){
        console.log(err);
    }
}
