import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { PostProduct } from '../Api';
import { useState } from 'react';
import { Col, Row } from 'react-bootstrap';

export function PostForm() {
  const [price, setPrice] = useState(0);
  const [category, setCategory] = useState(0);
  return (
    <Form onSubmit={ (e) => { e.preventDefault(); PostProduct(price, category); setPrice(1); setCategory(1) } }>
        <Row>
            <Col xs={3}>
                <Form.Group className="mb-3" controlId="formBasicPrice">
                    <Form.Label>Precio del producto</Form.Label>
                    <Form.Control
                        type="number" min="1" max="1000" step="1" value={price} required placeholder="Ingrese el precio del producto" 
                        onChange={e => setPrice(parseInt(e.target.value))}
                    />
                    <Form.Text className="text-muted">
                    Maximo 1000
                    </Form.Text>
                </Form.Group>
            </Col>
            <Col xs={3}>
                <Form.Group className="mb-3" controlId="formBasicCategory">
                    <Form.Label>Categoria</Form.Label>
                    <Form.Control 
                        type="number" min="1" max="2" step="1" value={category} required placeholder="Ingrese 1 o 2 para la categoria" 
                        onChange={e => setCategory(parseInt(e.target.value))}
                    />
                </Form.Group>
            </Col>
        </Row>
        <Button variant="primary" type="submit" value="Submit">
            Enviar
        </Button>
    </Form>
  );
}