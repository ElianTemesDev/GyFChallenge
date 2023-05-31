import { useState, useEffect } from 'react'
import { GetAllProducts } from './Api'
import { ProductTable, Product } from './components/ProductTable';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css'
import { NavbarCustom } from './components/Navbar';
import { PostForm } from './components/PostForm';
import { BudgetSale } from './components/BudgetSale';

function App() {
  const [products, setProducts] = useState(new Array<Product>());
  useEffect(() => {
    GetAllProducts().then(productList => setProducts(productList)); 
  }, []);
  return (
    <>
      <NavbarCustom getAllProducts={GetAllProducts} setProducts={setProducts}></NavbarCustom>    
      <br></br>
      <Container>
        <h2>Carga de producto: </h2>
        <br></br>
        <PostForm></PostForm>
      </Container>
      <hr />
      <Container>
        <h2>Tabla de productos: </h2>
        <br></br>
        <Row>
          <Col>
            <ProductTable items={products} start={0} end={products.length / 4}></ProductTable>
          </Col>
          <Col>
            <ProductTable items={products} start={products.length / 4} end={products.length / 2}></ProductTable>
          </Col>
          <Col>
            <ProductTable items={products} start={products.length / 2} end={products.length - products.length / 4}></ProductTable>
          </Col>
          <Col>
            <ProductTable items={products} start={products.length - products.length / 4} end={products.length}></ProductTable>
          </Col>
        </Row>
      </Container>
      <hr />
      <Container>
        <h2>Venta por presupuesto: </h2>
        <br></br>
        <BudgetSale></BudgetSale>
      </Container>
    </>
  )
}

export default App
